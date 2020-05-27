package org.rub.nds.pdf.pdfsigner;

import java.awt.Color;
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.util.Calendar;
import java.util.List;
import org.apache.commons.cli.CommandLine;
import org.apache.pdfbox.pdmodel.PDDocument;
import org.apache.pdfbox.pdmodel.PDPage;
import org.apache.pdfbox.pdmodel.PDPageContentStream;
import org.apache.pdfbox.pdmodel.PDResources;
import org.apache.pdfbox.pdmodel.common.PDObjectStream;
import org.apache.pdfbox.pdmodel.common.PDRectangle;
import org.apache.pdfbox.pdmodel.common.PDStream;
import org.apache.pdfbox.pdmodel.font.PDFont;
import org.apache.pdfbox.pdmodel.font.PDType1Font;
import org.apache.pdfbox.pdmodel.graphics.form.PDFormXObject;
import org.apache.pdfbox.pdmodel.graphics.image.PDImageXObject;
import org.apache.pdfbox.pdmodel.interactive.annotation.PDAnnotationWidget;
import org.apache.pdfbox.pdmodel.interactive.annotation.PDAppearanceDictionary;
import org.apache.pdfbox.pdmodel.interactive.annotation.PDAppearanceStream;
import org.apache.pdfbox.pdmodel.interactive.digitalsignature.ExternalSigningSupport;
import org.apache.pdfbox.pdmodel.interactive.digitalsignature.PDSignature;
import org.apache.pdfbox.pdmodel.interactive.digitalsignature.SignatureInterface;
import org.apache.pdfbox.pdmodel.interactive.digitalsignature.SignatureOptions;
import org.apache.pdfbox.pdmodel.interactive.form.PDAcroForm;
import org.apache.pdfbox.pdmodel.interactive.form.PDField;
import org.apache.pdfbox.pdmodel.interactive.form.PDSignatureField;
import org.apache.pdfbox.util.Matrix;

/**
 *
 * @author vladi
 */
public class ApprovalSigner implements Signer {

    public static void sign(CommandLine cmd, PDDocument document, OutputStream outputFile, SignatureInterface signatureInterface) throws IOException {
        PDSignatureField signatureField = document.getSignatureFields().get(2);
        PDSignature signature = new PDSignature();
        signatureField.setValue(signature);
        sign(cmd, document, outputFile, signatureInterface, signatureField);
    }

    public static void sign(CommandLine cmd, PDDocument document, OutputStream outputFile, SignatureInterface signatureInterface, PDSignatureField signatureField) throws IOException {
        PDSignature signature = signatureField.getSignature();
        signature.setFilter(PDSignature.FILTER_ADOBE_PPKLITE);
        signature.setSubFilter(PDSignature.SUBFILTER_ADBE_PKCS7_DETACHED);
        signature.setName("PDF Insecurity Team");
        signature.setLocation("Bochum");
        signature.setReason("PDF Security Testing");
        signature.setSignDate(Calendar.getInstance());
        SignatureOptions sigOptions = new SignatureOptions();

        if (cmd.getOptionValue(ConfigurationManager.OPTIONS_SIGVIEW, "visible").equalsIgnoreCase("visible")) {
            sigOptions.setVisualSignature(createVisualSignatureTemplate(document, 0, signatureField.getWidgets().get(0).getRectangle(), cmd.getOptionValue(ConfigurationManager.OPTIONS_SIG_IMG, "")));
        }

        document.addSignature(signature, sigOptions);
        ExternalSigningSupport externalSigning
                = document.saveIncrementalForExternalSigning(outputFile);
        // invoke external signature service
        byte[] cmsSignature = signatureInterface.sign(externalSigning.getContent());
        // set signature bytes received from the service
        externalSigning.setSignature(cmsSignature);

    }

    // create a template PDF document with empty signature and return it as a stream.
    private static InputStream createVisualSignatureTemplate(PDDocument srcDoc, int pageNum, PDRectangle rect, String sigImgPath) throws IOException {
        try ( PDDocument doc = new PDDocument()) {
            PDPage page = new PDPage(srcDoc.getPage(pageNum).getMediaBox());
            doc.addPage(page);
            PDAcroForm acroForm = new PDAcroForm(doc);
//            PDAcroForm acroForm = doc.getDocumentCatalog().getAcroForm();
            doc.getDocumentCatalog().setAcroForm(acroForm);
            PDSignatureField signatureField = new PDSignatureField(acroForm);
            PDAnnotationWidget widget = signatureField.getWidgets().get(0);
            List<PDField> acroFormFields = acroForm.getFields();
            acroForm.setSignaturesExist(true);
            acroForm.setAppendOnly(true);
            acroForm.getCOSObject().setDirect(true);
            acroFormFields.add(signatureField);

            widget.setRectangle(new PDRectangle(rect.getWidth(), rect.getHeight()));

            // from PDVisualSigBuilder.createHolderForm()
            PDStream stream = new PDStream(doc);
            PDFormXObject form = new PDFormXObject(stream);
            PDResources res = new PDResources();
            form.setResources(res);
            form.setFormType(1);
            PDRectangle bbox = new PDRectangle(rect.getWidth(), rect.getHeight());
            float height = bbox.getHeight();
            Matrix initialScale = null;
            form.setBBox(bbox);
            PDFont font = PDType1Font.HELVETICA_BOLD;

            // from PDVisualSigBuilder.createAppearanceDictionary()
            PDAppearanceDictionary appearance = new PDAppearanceDictionary();
            appearance.getCOSObject().setDirect(true);
            PDAppearanceStream appearanceStream = new PDAppearanceStream(form.getCOSObject());
            appearance.setNormalAppearance(appearanceStream);
            widget.setAppearance(appearance);

            try ( PDPageContentStream cs = new PDPageContentStream(doc, appearanceStream)) {
                // for 90Â° and 270Â° scale ratio of width / height
                // not really sure about this
                // why does scale have no effect when done in the form matrix???
                if (initialScale != null) {
                    cs.transform(initialScale);
                }

                if (sigImgPath.isEmpty()) {
//                    cs.addRect(100, 100, 10000, 10000);
//                    cs.saveGraphicsState();
//                    // show background (just for debugging, to see the rect size + position)
                    cs.setNonStrokingColor(Color.lightGray);
                    cs.fill();

                    // show text
                    float fontSize = 10;
                    float leading = fontSize * 1.5f;
                    cs.beginText();
                    cs.setFont(font, fontSize);
                    cs.setNonStrokingColor(Color.white);
                    cs.newLineAtOffset(fontSize, height - leading);
                    cs.setLeading(leading);
                    cs.showText("(Digital Signature)");
                    cs.endText();
                } else {
                    // show background image
                    // save and restore graphics if the image is too large and needs to be scaled
//                    cs.transform(Matrix.getScaleInstance(.0f, 0.25f));
                    PDImageXObject img = PDImageXObject.createFromFileByExtension(new File(sigImgPath), doc);
                    cs.drawImage(img, 0, 0);
                    //cs.restoreGraphicsState();
                    cs.setNonStrokingColor(Color.BLACK);
                    cs.fill();

                    // show text eingefuegt
                    float fontSize = 8;
                    float leading = fontSize * 1.5f;
                    cs.beginText();
                    cs.setFont(font, fontSize);
                    cs.setNonStrokingColor(Color.black);
                    cs.newLineAtOffset(fontSize, height - leading);
                    cs.setLeading(leading);
                    cs.showText("Wir sind wie Socken: cool aber stinkend!");
                    cs.endText();
                    // bis hier hin
                }
            }

            // no need to set annotations and /P entry
            ByteArrayOutputStream baos = new ByteArrayOutputStream();
            doc.save(baos);
            return new ByteArrayInputStream(baos.toByteArray());
        }
    }

    // create a template PDF document with empty signature and return it as a stream.
    private static InputStream createVisualSignatureTemplate2(PDDocument srcDoc, int pageNum, PDRectangle rect, String sigImgPath) throws IOException {
//        PDAcroForm acroForm = new PDAcroForm(srcDoc);
            PDAcroForm acroForm = srcDoc.getDocumentCatalog().getAcroForm();
//        srcDoc.getDocumentCatalog().setAcroForm(acroForm);
        PDSignatureField signatureField = srcDoc.getSignatureFields().get(2);
        PDAnnotationWidget widget =  signatureField.getWidgets().get(0);
//        List<PDField> acroFormFields = acroForm.getFields();
//        acroForm.setSignaturesExist(true);
//        acroForm.setAppendOnly(true);
//        acroForm.getCOSObject().setDirect(true);
//        acroFormFields.add(srcDoc.getSignatureFields().get(0));
//        acroFormFields.add(signatureField);

        //Simon: You can adapt the position here 
        widget.setRectangle(new PDRectangle(new Float(51.8),new Float(758.0),new Float(107.0),new Float(12.0)));

        // from PDVisualSigBuilder.createHolderForm()
        PDStream stream = new PDStream(srcDoc);
        PDFormXObject form = new PDFormXObject(stream);
        PDResources res = new PDResources();
        form.setResources(res);
        form.setFormType(1);
        PDRectangle bbox = new PDRectangle(new Float(51.8),new Float(758.0),new Float(107.0),new Float(12.0));
        float height = bbox.getHeight();
        Matrix initialScale = null;
        form.setBBox(bbox);
        PDFont font = PDType1Font.HELVETICA_BOLD;

        // from PDVisualSigBuilder.createAppearanceDictionary()
        PDAppearanceDictionary appearance = new PDAppearanceDictionary();
        appearance.getCOSObject().setDirect(true);
        PDAppearanceStream appearanceStream = new PDAppearanceStream(form.getCOSObject());
        appearance.setNormalAppearance(appearanceStream);
        widget.setAppearance(appearance);

        try ( PDPageContentStream cs = new PDPageContentStream(srcDoc, appearanceStream)) {
            // for 90Â° and 270Â° scale ratio of width / height
            // not really sure about this
            // why does scale have no effect when done in the form matrix???
            if (initialScale != null) {
                cs.transform(initialScale);
            }

            if (sigImgPath.isEmpty()) {
//                    cs.addRect(100, 100, 10000, 10000);
//                    cs.saveGraphicsState();
//                    // show background (just for debugging, to see the rect size + position)
                cs.setNonStrokingColor(Color.lightGray);
                cs.fill();

                // show text
                float fontSize = 10;
                float leading = fontSize * 1.5f;
                cs.beginText();
                cs.setFont(font, fontSize);
                cs.setNonStrokingColor(Color.black);
                cs.newLineAtOffset(fontSize, height - leading);
                cs.setLeading(leading);
                cs.showText("(Digital Signature)");
                cs.endText();
            } else {
                // show background image
                // save and restore graphics if the image is too large and needs to be scaled
                //cs.transform(Matrix.getScaleInstance(0.25f, 0.25f));
                PDImageXObject img = PDImageXObject.createFromFileByExtension(new File(sigImgPath), srcDoc);
                cs.drawImage(img, 0, 0);
                //cs.restoreGraphicsState();
                cs.setNonStrokingColor(Color.BLACK);
                cs.fill();

                // show text eingefuegt
                float fontSize = 10;
                float leading = fontSize * 1.5f;
                cs.beginText();
                cs.setFont(font, fontSize);
                cs.setNonStrokingColor(Color.black);
                cs.newLineAtOffset(fontSize, height - leading);
                cs.setLeading(leading);
                cs.showText("AAAAAAAAAAAAAAAAAAAAAAAA");
                cs.endText();
                // bis hier hin
            }
        }

        // no need to set annotations and /P entry
        ByteArrayOutputStream baos = new ByteArrayOutputStream();
        srcDoc.save(baos);
        return new ByteArrayInputStream(baos.toByteArray());
    }
}
