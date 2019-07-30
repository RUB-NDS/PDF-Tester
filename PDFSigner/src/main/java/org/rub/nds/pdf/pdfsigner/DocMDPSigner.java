package org.rub.nds.pdf.pdfsigner;

import java.io.IOException;
import java.io.OutputStream;
import org.apache.commons.cli.CommandLine;
import org.apache.pdfbox.cos.COSArray;
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
public class DocMDPSigner implements Signer{

    public static void sign(CommandLine cmd, PDDocument document, OutputStream outputFile, SignatureInterface signatureInterface) throws IOException{
        PDSignatureField signatureField = document.getSignatureFields().get(0);
        PDSignature signature = new PDSignature();
        signatureField.setValue(signature);

//        COSBase lock = signatureField.getCOSObject().getDictionaryObject(COS_NAME_LOCK);
        //if (lock instanceof COSDictionary) {
//        COSDictionary lockDict = (COSDictionary) lock;
        COSDictionary transformParams = new COSDictionary();
//        if (cmd.getOptionValue(ConfigurationManager.OPTIONS_LOCK, "false").equalsIgnoreCase(Boolean.TRUE.toString())) {
//            transformParams = new COSDictionary(lockDict);
//        } else {
//            transformParams = new COSDictionary();
//        }
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
//        signature.getCOSObject().setItem(COS_NAME_ALL, lock);
        //}
        COSDictionary catalogDict = document.getDocumentCatalog().getCOSObject();
        COSDictionary permsDict = new COSDictionary();
        catalogDict.setItem(COSName.PERMS, permsDict);
        permsDict.setItem(COSName.DOCMDP, signature);
        catalogDict.setNeedToBeUpdated(true);
        permsDict.setNeedToBeUpdated(true);

        ApprovalSigner.sign(cmd, document, outputFile, signatureInterface, signatureField);
    }
    
}
