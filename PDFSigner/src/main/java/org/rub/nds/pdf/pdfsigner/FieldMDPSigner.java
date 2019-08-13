package org.rub.nds.pdf.pdfsigner;

import java.io.IOException;
import java.io.OutputStream;
import org.apache.commons.cli.CommandLine;
import org.apache.pdfbox.cos.COSArray;
import org.apache.pdfbox.cos.COSBase;
import org.apache.pdfbox.cos.COSDictionary;
import org.apache.pdfbox.cos.COSName;
import org.apache.pdfbox.pdmodel.PDDocument;
import org.apache.pdfbox.pdmodel.interactive.digitalsignature.PDSignature;
import org.apache.pdfbox.pdmodel.interactive.digitalsignature.SignatureInterface;
import org.apache.pdfbox.pdmodel.interactive.form.PDSignatureField;

/**
 *
 * @author vladi
 */
public class FieldMDPSigner {

    public static final COSName COS_NAME_LOCK = COSName.getPDFName("Lock");
    public static final COSName COS_NAME_ALL = COSName.getPDFName("All");
    public static final COSName COS_NAME_EXCLUDE = COSName.getPDFName("Exclude");
    public static final COSName COS_NAME_INCLUDE = COSName.getPDFName("Include");
    
    public static void sign(CommandLine cmd, PDDocument document, OutputStream outputFile, SignatureInterface signatureInterface) throws IOException {
        PDSignatureField signatureField = document.getSignatureFields().get(0);

        PDSignature signature = new PDSignature();
        signatureField.setValue(signature);

        if (cmd.getOptionValue(ConfigurationManager.OPTIONS_LOCK, "false").equalsIgnoreCase("true")) {
            SignUtils.setLock(signatureField, document.getDocumentCatalog().getAcroForm(), cmd);
        }

        COSBase lock = signatureField.getCOSObject().getDictionaryObject(COS_NAME_LOCK);
        if (lock == null) {
            lock = new COSDictionary();

        }
        COSDictionary lockDict = (COSDictionary) lock;
        if (cmd.getOptionValue(ConfigurationManager.OPTIONS_FIELDMDP_ACTION, "all").equalsIgnoreCase("all")) {
            lockDict.setItem(SignUtils.COS_NAME_ACTION, COS_NAME_ALL);
        } else {
            if (cmd.getOptionValue(ConfigurationManager.OPTIONS_FIELDMDP_ACTION).equalsIgnoreCase("include"))
            {
                lockDict.setItem(SignUtils.COS_NAME_ACTION, COS_NAME_INCLUDE);
                SignUtils.extractFieldMDPFields(cmd, lockDict);
            }
            else if (cmd.getOptionValue(ConfigurationManager.OPTIONS_FIELDMDP_ACTION).equalsIgnoreCase("exclude"))
            {
                lockDict.setItem(SignUtils.COS_NAME_ACTION, COS_NAME_EXCLUDE);
                SignUtils.extractFieldMDPFields(cmd, lockDict);
            }
            else{
                lockDict.setItem(SignUtils.COS_NAME_ACTION, COS_NAME_ALL);
            }
           
            
            
        }

        lockDict.setInt(COSName.P, 1);
        COSDictionary transformParams = new COSDictionary(lockDict);

        transformParams.setItem(COSName.TYPE, COSName.getPDFName("TransformParams"));
        transformParams.setItem(COSName.V, COSName.getPDFName("1.2"));
        transformParams.setDirect(false);
        COSDictionary sigRef = new COSDictionary();
        sigRef.setItem(COSName.TYPE, COSName.getPDFName("SigRef"));
        sigRef.setItem(COSName.DIGEST_METHOD, COSName.DIGEST_SHA256);
        sigRef.setItem(COSName.getPDFName("TransformParams"), transformParams);
        sigRef.setItem(COSName.getPDFName("TransformMethod"), COSName.getPDFName("FieldMDP"));
        sigRef.setDirect(false);
        COSArray referenceArray = new COSArray();
        referenceArray.add(sigRef);
        signature.getCOSObject().setItem(COSName.getPDFName("Reference"), referenceArray);
        signature.getCOSObject().setItem(COS_NAME_ALL, lock);
        //}

        ApprovalSigner.sign(cmd, document, outputFile, signatureInterface, signatureField);
    }
}
