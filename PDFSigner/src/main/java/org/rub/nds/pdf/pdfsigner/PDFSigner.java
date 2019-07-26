package org.rub.nds.pdf.pdfsigner;

import java.io.ByteArrayInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.security.KeyStore;
import java.security.KeyStoreException;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.security.PrivateKey;
import java.security.Security;
import java.security.UnrecoverableKeyException;
import java.security.cert.Certificate;
import java.security.cert.CertificateException;
import java.security.cert.CertificateFactory;
import java.security.cert.X509Certificate;
import java.util.Arrays;
import java.util.Calendar;
import java.util.List;
import org.apache.pdfbox.cos.COSArray;
import org.apache.pdfbox.cos.COSBase;
import org.apache.pdfbox.cos.COSDictionary;
import org.apache.pdfbox.cos.COSName;
import org.apache.pdfbox.io.IOUtils;
import org.apache.pdfbox.pdmodel.PDDocument;
import org.apache.pdfbox.pdmodel.common.PDRectangle;
import org.apache.pdfbox.pdmodel.interactive.digitalsignature.ExternalSigningSupport;
import org.apache.pdfbox.pdmodel.interactive.digitalsignature.PDSignature;
import org.apache.pdfbox.pdmodel.interactive.digitalsignature.SignatureInterface;
import org.apache.pdfbox.pdmodel.interactive.form.PDAcroForm;
import org.apache.pdfbox.pdmodel.interactive.form.PDSignatureField;
import org.bouncycastle.asn1.ASN1EncodableVector;
import org.bouncycastle.asn1.DEROctetString;
import org.bouncycastle.asn1.DERSet;
import org.bouncycastle.asn1.cms.CMSAttributes;
import org.bouncycastle.cert.jcajce.JcaCertStore;
import org.bouncycastle.cms.CMSSignedDataGenerator;
import org.bouncycastle.asn1.cms.Attribute;
import org.bouncycastle.asn1.cms.AttributeTable;
import org.bouncycastle.asn1.x509.AlgorithmIdentifier;
import org.bouncycastle.cert.jcajce.JcaX509CertificateHolder;
import org.bouncycastle.cms.CMSAbsentContent;
import org.bouncycastle.cms.CMSSignedData;
import org.bouncycastle.cms.DefaultSignedAttributeTableGenerator;
import org.bouncycastle.cms.SignerInfoGeneratorBuilder;
import org.bouncycastle.crypto.util.PrivateKeyFactory;
import org.bouncycastle.jce.provider.BouncyCastleProvider;
import org.bouncycastle.operator.DefaultDigestAlgorithmIdentifierFinder;
import org.bouncycastle.operator.DefaultSignatureAlgorithmIdentifierFinder;
import org.bouncycastle.operator.bc.BcDigestCalculatorProvider;
import org.bouncycastle.operator.bc.BcRSAContentSignerBuilder;
import org.apache.commons.cli.*;
import org.apache.pdfbox.cos.COSObject;
import org.apache.pdfbox.cos.COSObjectKey;

/**
 *
 * @author vladi
 */
public class PDFSigner {

    /**
     * @param args the command line arguments
     */
    public static final COSName COS_NAME_LOCK = COSName.getPDFName("Lock");
    public static final COSName COS_NAME_ALL = COSName.getPDFName("All");

    public static String KEYSTORE = "./keystores/demo-rsa2048.p12";
    public static char[] PASSWORD = "demo-rsa2048".toCharArray();

    private static final String OPTIONS_INPUT = "i";
    private static final String OPTIONS_OUTPUT = "o";
    private static final String OPTIONS_JKS = "jks";
    private static final String OPTIONS_PKCS = "pkcs";
    private static final String OPTIONS_PASSWORD = "p";
    private static final String OPTIONS_SIGTYPE = "sigtype";
    private static final String OPTIONS_SIGVIEW = "sigview";
    private static final String OPTIONS_LOCK = "lock";

    public static KeyStore ks = null;
    public static PrivateKey pk = null;
    public static Certificate[] chain = null;

    public static void main(String[] args) throws IOException, KeyStoreException, NoSuchAlgorithmException, CertificateException, UnrecoverableKeyException {
        CommandLine cmd = init(args);
        sign(cmd);
    }

    private static CommandLine init(String[] args) throws KeyStoreException, FileNotFoundException, IOException, NoSuchAlgorithmException, CertificateException, UnrecoverableKeyException {
        CommandLine cmd = commandLineParserInit(args);
        ClassLoader classLoader = PDFSigner.class.getClassLoader();
        initKeys(cmd);
        return cmd;
    }

    private static CommandLine commandLineParserInit(String[] args) {
        Options options = new Options();

        Option inputFile = new Option(OPTIONS_INPUT, "input", true, "inputFile file path");
        inputFile.setRequired(true);
        options.addOption(inputFile);

        Option outputFile = new Option(OPTIONS_OUTPUT, "output", true, "outputFile file");
        outputFile.setRequired(true);
        options.addOption(outputFile);

        Option jksFile = new Option(OPTIONS_JKS, "jksFile", true, "JavaKeyStore file");
        jksFile.setRequired(false);
        options.addOption(jksFile);

        Option pkcs12File = new Option(OPTIONS_PKCS, "pkcsFile", true, "PKCS12 file");
        pkcs12File.setRequired(false);
        options.addOption(pkcs12File);

        Option password = new Option(OPTIONS_PASSWORD, "password", true, "JKS/PKCS12 password to access the private keys");
        password.setRequired(false);
        options.addOption(password);

        Option signatureType = new Option(OPTIONS_SIGTYPE, true, "Signature Type: approval/certified (default)");
        signatureType.setRequired(false);
        options.addOption(signatureType);

        Option sigview = new Option(OPTIONS_SIGVIEW, true, "Signature view: visible (default)/invisible");
        sigview.setRequired(false);
        options.addOption(sigview);

        Option lockPDF = new Option(OPTIONS_LOCK, true, "Lock PDF: true/false (default)");
        lockPDF.setRequired(false);
        options.addOption(lockPDF);

        CommandLineParser parser = new DefaultParser();
        HelpFormatter formatter = new HelpFormatter();
        CommandLine cmd;

        try {
            cmd = parser.parse(options, args);
            return cmd;
        } catch (ParseException e) {
            System.out.println(e.getMessage());
            formatter.printHelp("utility-name", options);
            System.exit(1);
            return null;
        }
    }

    private static void initKeys(CommandLine cmd) throws IOException, CertificateException, NoSuchAlgorithmException, KeyStoreException, UnrecoverableKeyException {
        if (cmd.getOptionValue(OPTIONS_PKCS) != null && !cmd.getOptionValue(OPTIONS_PKCS).isEmpty()) {
            KEYSTORE = cmd.getOptionValue(OPTIONS_PKCS);
        } else if (cmd.getOptionValue(OPTIONS_JKS) != null && !cmd.getOptionValue(OPTIONS_JKS).isEmpty()) {
            KEYSTORE = cmd.getOptionValue(OPTIONS_JKS);
        }

        if (cmd.getOptionValue(OPTIONS_PASSWORD) != null && !cmd.getOptionValue(OPTIONS_PASSWORD).isEmpty()) {
            PASSWORD = cmd.getOptionValue(OPTIONS_PASSWORD).toCharArray();
        }

        BouncyCastleProvider bcp = new BouncyCastleProvider();
        Security.insertProviderAt(bcp, 1);

        ks = KeyStore.getInstance(KeyStore.getDefaultType());
        ks.load(new FileInputStream(KEYSTORE), PASSWORD);
        String alias = (String) ks.aliases().nextElement();
        pk = (PrivateKey) ks.getKey(alias, PASSWORD);
        chain = ks.getCertificateChain(alias);
    }

    private static void sign(CommandLine cmd) throws IOException {
        String inputFile = cmd.getOptionValue(OPTIONS_INPUT);
        String outputFile = cmd.getOptionValue(OPTIONS_OUTPUT);

        OutputStream result = new FileOutputStream(new File(outputFile));
        PDDocument pdDocument = PDDocument.load(new File(cmd.getOptionValue(OPTIONS_INPUT)));

        insertEmptySignature(cmd, result, pdDocument);

        if (cmd.getOptionValue(OPTIONS_SIGTYPE, "certified").equalsIgnoreCase("certified")) {
            signCertify(cmd, pdDocument, result, data -> signWithSeparatedHashing(data));
        } else {
            signApproval(pdDocument, result, data -> signWithSeparatedHashing(data));
        }
    }

    private static void insertEmptySignature(CommandLine cmd, OutputStream result, PDDocument pdDocument) throws IOException {
        PDAcroForm acroForm = pdDocument.getDocumentCatalog().getAcroForm();
        if (acroForm == null) {
            acroForm = new PDAcroForm(pdDocument);
            pdDocument.getDocumentCatalog().setAcroForm(acroForm);
        }
        PDSignatureField signatureField = new PDSignatureField(acroForm);
        acroForm.getFields().add(signatureField);
        signatureField.getWidgets().get(0).setPage(pdDocument.getPage(0));
        pdDocument.getPage(0).getAnnotations().add(signatureField.getWidgets().get(0));

        if (cmd.getOptionValue(OPTIONS_SIGVIEW, "visible").equals("visible")) {
            signatureField.getWidgets().get(0).setRectangle(new PDRectangle(100, 600, 300, 200));
        } else {
            signatureField.getWidgets().get(0).setRectangle(new PDRectangle(0, 0, 0, 0));
        }

        if (cmd.getOptionValue(OPTIONS_LOCK, "false").equalsIgnoreCase(Boolean.TRUE.toString())) {
            setLock(signatureField, acroForm);
        }
    }

    public static void setLock(PDSignatureField pdSignatureField, PDAcroForm acroForm) {
        COSName COS_NAME_ACTION = COSName.getPDFName("Action");
        COSName COS_NAME_SIG_FIELD_LOCK = COSName.getPDFName("SigFieldLock");
        
        COSDictionary lockDict = new COSDictionary();
        lockDict.setItem(COS_NAME_ACTION, COS_NAME_ALL);
        lockDict.setItem(COSName.TYPE, COS_NAME_SIG_FIELD_LOCK);
        pdSignatureField.getCOSObject().setItem(COS_NAME_LOCK, lockDict);
    }

    private static void signApproval(PDDocument document, OutputStream outputFile, SignatureInterface signatureInterface) throws IOException {
        PDSignatureField signatureField = document.getSignatureFields().get(0);
        PDSignature signature = new PDSignature();
        signatureField.setValue(signature);
        signApproval(document, outputFile, signatureInterface, signatureField);

    }

    private static void signApproval(PDDocument document, OutputStream outputFile, SignatureInterface signatureInterface, PDSignatureField signatureField) throws IOException {
        PDSignature signature = signatureField.getSignature();
        signature.setFilter(PDSignature.FILTER_ADOBE_PPKLITE);
        signature.setSubFilter(PDSignature.SUBFILTER_ADBE_PKCS7_DETACHED);
        signature.setName("PDF Insecurity Team");
        signature.setLocation("Bochum");
        signature.setReason("PDF Security Testing");
        signature.setSignDate(Calendar.getInstance());
        document.addSignature(signature);
        ExternalSigningSupport externalSigning
                = document.saveIncrementalForExternalSigning(outputFile);
        // invoke external signature service
        byte[] cmsSignature = signatureInterface.sign(externalSigning.getContent());
        // set signature bytes received from the service
        externalSigning.setSignature(cmsSignature);

    }

    private static void signCertify(CommandLine cmd, PDDocument document, OutputStream outputFile, SignatureInterface signatureInterface) throws IOException {

        PDSignatureField signatureField = document.getSignatureFields().get(0);
        PDSignature signature = new PDSignature();
        signatureField.setValue(signature);

        COSBase lock = signatureField.getCOSObject().getDictionaryObject(COS_NAME_LOCK);
        //if (lock instanceof COSDictionary) {
        COSDictionary lockDict = (COSDictionary) lock;
        COSDictionary transformParams;
        if (cmd.getOptionValue(OPTIONS_LOCK, "false").equalsIgnoreCase(Boolean.TRUE.toString())) {
            transformParams = new COSDictionary(lockDict);
        } else {
            transformParams = new COSDictionary();
        }
        transformParams.setItem(COSName.TYPE, COSName.getPDFName("TransformParams"));
        transformParams.setItem(COSName.V, COSName.getPDFName("1.2"));
        transformParams.setInt(COSName.P, 2);  // SEHR WICHTIG: ADOBE erkennt keinen Certificate ansonst
        transformParams.setDirect(false);
        COSDictionary sigRef = new COSDictionary();
        sigRef.setItem(COSName.TYPE, COSName.getPDFName("SigRef"));
        sigRef.setItem(COSName.DIGEST_METHOD, COSName.DIGEST_SHA256);
        sigRef.setItem(COSName.getPDFName("TransformParams"), transformParams);
        sigRef.setItem(COSName.getPDFName("TransformMethod"), COSName.getPDFName("DocMDP"));
        //sigRef.setItem(COSName.getPDFName("Data"), document.getDocumentCatalog());
        sigRef.setDirect(false);
        COSArray referenceArray = new COSArray();
        referenceArray.add(sigRef);
        signature.getCOSObject().setItem(COSName.getPDFName("Reference"), referenceArray);
        signature.getCOSObject().setItem(COS_NAME_ALL, lock);
        //}
        COSDictionary catalogDict = document.getDocumentCatalog().getCOSObject();
        COSDictionary permsDict = new COSDictionary();
        catalogDict.setItem(COSName.PERMS, permsDict);
        permsDict.setItem(COSName.DOCMDP, signature);
        catalogDict.setNeedToBeUpdated(true);
        permsDict.setNeedToBeUpdated(true);

        signApproval(document, outputFile, signatureInterface, signatureField);
    }

    private static byte[] signWithSeparatedHashing(InputStream content) throws IOException {
        try {
            // Digest generation step
            MessageDigest md = MessageDigest.getInstance("SHA256", "BC");
            byte[] digest = md.digest(IOUtils.toByteArray(content));

            // Separate signature container creation step
            List<Certificate> certList = Arrays.asList(chain);
            JcaCertStore certs = new JcaCertStore(certList);

            CMSSignedDataGenerator gen = new CMSSignedDataGenerator();

            Attribute attr = new Attribute(CMSAttributes.messageDigest,
                    new DERSet(new DEROctetString(digest)));

            ASN1EncodableVector v = new ASN1EncodableVector();

            v.add(attr);

            SignerInfoGeneratorBuilder builder = new SignerInfoGeneratorBuilder(new BcDigestCalculatorProvider())
                    .setSignedAttributeGenerator(new DefaultSignedAttributeTableGenerator(new AttributeTable(v)));

            AlgorithmIdentifier sha256withRSA = new DefaultSignatureAlgorithmIdentifierFinder().find("SHA256withRSA");

            CertificateFactory certFactory = CertificateFactory.getInstance("X.509");
            InputStream in = new ByteArrayInputStream(chain[0].getEncoded());
            X509Certificate cert = (X509Certificate) certFactory.generateCertificate(in);

            gen.addSignerInfoGenerator(builder.build(
                    new BcRSAContentSignerBuilder(sha256withRSA,
                            new DefaultDigestAlgorithmIdentifierFinder().find(sha256withRSA))
                            .build(PrivateKeyFactory.createKey(pk.getEncoded())),
                    new JcaX509CertificateHolder(cert)));

            gen.addCertificates(certs);

            CMSSignedData s = gen.generate(new CMSAbsentContent(), false);
            return s.getEncoded();
        } catch (Exception e) {
            e.printStackTrace();
            throw new IOException(e);
        }
    }

}
