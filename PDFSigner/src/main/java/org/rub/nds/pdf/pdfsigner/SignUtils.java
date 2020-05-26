package org.rub.nds.pdf.pdfsigner;

import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.security.MessageDigest;
import java.security.cert.Certificate;
import java.security.cert.CertificateFactory;
import java.security.cert.X509Certificate;
import java.util.Arrays;
import java.util.List;
import org.apache.commons.cli.CommandLine;
import org.apache.pdfbox.cos.COSArray;
import org.apache.pdfbox.cos.COSDictionary;
import org.apache.pdfbox.cos.COSName;
import org.apache.pdfbox.cos.COSString;
import org.apache.pdfbox.io.IOUtils;
import org.apache.pdfbox.pdmodel.PDDocument;
import org.apache.pdfbox.pdmodel.common.PDRectangle;
import org.apache.pdfbox.pdmodel.interactive.form.PDAcroForm;
import org.apache.pdfbox.pdmodel.interactive.form.PDSignatureField;
import org.bouncycastle.asn1.ASN1EncodableVector;
import org.bouncycastle.asn1.DEROctetString;
import org.bouncycastle.asn1.DERSet;
import org.bouncycastle.asn1.cms.Attribute;
import org.bouncycastle.asn1.cms.AttributeTable;
import org.bouncycastle.asn1.cms.CMSAttributes;
import org.bouncycastle.asn1.x509.AlgorithmIdentifier;
import org.bouncycastle.cert.jcajce.JcaCertStore;
import org.bouncycastle.cert.jcajce.JcaX509CertificateHolder;
import org.bouncycastle.cms.CMSAbsentContent;
import org.bouncycastle.cms.CMSSignedData;
import org.bouncycastle.cms.CMSSignedDataGenerator;
import org.bouncycastle.cms.DefaultSignedAttributeTableGenerator;
import org.bouncycastle.cms.SignerInfoGeneratorBuilder;
import org.bouncycastle.crypto.util.PrivateKeyFactory;
import org.bouncycastle.operator.DefaultDigestAlgorithmIdentifierFinder;
import org.bouncycastle.operator.DefaultSignatureAlgorithmIdentifierFinder;
import org.bouncycastle.operator.bc.BcDigestCalculatorProvider;
import org.bouncycastle.operator.bc.BcRSAContentSignerBuilder;

/**
 *
 * @author vladi
 */
public class SignUtils {
    public static final COSName COS_NAME_LOCK = COSName.getPDFName("Lock");
    public static final COSName COS_NAME_ACTION = COSName.getPDFName("Action");
    public static final COSName COS_NAME_ALL = COSName.getPDFName("All");
    public static final COSName COS_NAME_SIG_FIELD_LOCK = COSName.getPDFName("SigFieldLock");

    public static byte[] signWithSeparatedHashing(InputStream content) throws IOException {
        try {
            // Digest generation step
            MessageDigest md = MessageDigest.getInstance("SHA256", "BC");
            byte[] digest = md.digest(IOUtils.toByteArray(content));

            // Separate signature container creation step
            List<Certificate> certList = Arrays.asList(ConfigurationManager.chain);
            JcaCertStore certs = new JcaCertStore(certList);

            CMSSignedDataGenerator gen = new CMSSignedDataGenerator();

            Attribute attr = new Attribute(CMSAttributes.messageDigest, new DERSet(new DEROctetString(digest)));

            ASN1EncodableVector v = new ASN1EncodableVector();

            v.add(attr);

            SignerInfoGeneratorBuilder builder = new SignerInfoGeneratorBuilder(new BcDigestCalculatorProvider())
                    .setSignedAttributeGenerator(new DefaultSignedAttributeTableGenerator(new AttributeTable(v)));

            AlgorithmIdentifier sha256withRSA = new DefaultSignatureAlgorithmIdentifierFinder().find("SHA256withRSA");

            CertificateFactory certFactory = CertificateFactory.getInstance("X.509");
            InputStream in = new ByteArrayInputStream(ConfigurationManager.chain[0].getEncoded());
            X509Certificate cert = (X509Certificate) certFactory.generateCertificate(in);

            gen.addSignerInfoGenerator(builder.build(
                    new BcRSAContentSignerBuilder(sha256withRSA,
                            new DefaultDigestAlgorithmIdentifierFinder().find(sha256withRSA))
                                    .build(PrivateKeyFactory.createKey(ConfigurationManager.pk.getEncoded())),
                    new JcaX509CertificateHolder(cert)));

            gen.addCertificates(certs);

            CMSSignedData s = gen.generate(new CMSAbsentContent(), false);
            return s.getEncoded();
        } catch (Exception e) {
            e.printStackTrace();
            throw new IOException(e);
        }
    }

    public static void insertEmptySignature(CommandLine cmd, OutputStream result, PDDocument pdDocument)
            throws IOException {
        PDAcroForm acroForm = pdDocument.getDocumentCatalog().getAcroForm();
        if (acroForm == null) {
            acroForm = new PDAcroForm(pdDocument);
            pdDocument.getDocumentCatalog().setAcroForm(acroForm);
        }
        
        PDSignatureField signatureField;
//        if (pdDocument.getSignatureFields().size()==0)
            signatureField = new PDSignatureField(acroForm);
//        else
//            signatureField = pdDocument.getSignatureFields().get(0);
        
        signatureField.setAlternateFieldName("Digital Signature");
        // signatureField.setValue("Digital Signature");

        acroForm.getFields().add(signatureField);
        signatureField.getWidgets().get(0).setPage(pdDocument.getPage(0));
        pdDocument.getPage(0).getAnnotations().add(signatureField.getWidgets().get(0));

        if (cmd.getOptionValue(ConfigurationManager.OPTIONS_SIGVIEW, "visible").equals("visible")) {
            signatureField.getWidgets().get(0).setRectangle(new PDRectangle(0, 0, 612, 792));
        } else {
            signatureField.getWidgets().get(0).setRectangle(new PDRectangle(0, 0, 0, 0));
        }

        if (cmd.getOptionValue(ConfigurationManager.OPTIONS_LOCK, "false").equalsIgnoreCase(Boolean.TRUE.toString())) {
            setLock(signatureField, acroForm, cmd);
        }
    }

    public static void setLock(PDSignatureField pdSignatureField, PDAcroForm acroForm, CommandLine cmd) {
        COSDictionary lockDict = new COSDictionary();
        if (cmd.getOptionValue(ConfigurationManager.OPTIONS_LOCK_FIELDS) == null
                || cmd.getOptionValue(ConfigurationManager.OPTIONS_LOCK_FIELDS).isEmpty()) {
            lockDict.setItem(COS_NAME_ACTION, COS_NAME_ALL);
        }
        else{
            lockDict.setItem(COS_NAME_ACTION, COSName.getPDFName("Include"));
            extractLockFields(cmd, lockDict);
        }
        lockDict.setItem(COSName.TYPE, COS_NAME_SIG_FIELD_LOCK);
        pdSignatureField.getCOSObject().setItem(COS_NAME_LOCK, lockDict);
    }

    public static void extractFieldMDPFields(CommandLine cmd, COSDictionary lockDict) {
        String[] fields = cmd.getOptionValue(ConfigurationManager.OPTIONS_FIELDMDP_FIELDS, "").split(",");
        COSArray signedFields = new COSArray();
        for (String s : fields) {
            signedFields.add(new COSString(s));
        }
        lockDict.setItem(COSName.FIELDS, signedFields);
    }

    public static void extractLockFields(CommandLine cmd, COSDictionary lockDict) {
        String[] fields = cmd.getOptionValue(ConfigurationManager.OPTIONS_LOCK_FIELDS, "").split(",");
        COSArray signedFields = new COSArray();
        for (String s : fields) {
            signedFields.add(new COSString(s));
        }
        lockDict.setItem(COSName.FIELDS, signedFields);
    }
}
