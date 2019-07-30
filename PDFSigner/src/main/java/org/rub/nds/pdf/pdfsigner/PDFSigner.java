package org.rub.nds.pdf.pdfsigner;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.OutputStream;
import java.security.KeyStoreException;
import java.security.NoSuchAlgorithmException;
import java.security.UnrecoverableKeyException;
import java.security.cert.CertificateException;
import org.apache.pdfbox.pdmodel.PDDocument;
import org.apache.commons.cli.*;

/**
 *
 * @author vladi
 */
public class PDFSigner {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) throws IOException, KeyStoreException, NoSuchAlgorithmException, CertificateException, UnrecoverableKeyException {
        CommandLine cmd = ConfigurationManager.init(args);
        sign(cmd);
    }

    private static void sign(CommandLine cmd) throws IOException {
        OutputStream result = new FileOutputStream(new File(cmd.getOptionValue(ConfigurationManager.OPTIONS_OUTPUT)));
        PDDocument pdDocument = PDDocument.load(new File(cmd.getOptionValue(ConfigurationManager.OPTIONS_INPUT)));

        SignUtils.insertEmptySignature(cmd, result, pdDocument);

        if (cmd.getOptionValue(ConfigurationManager.OPTIONS_SIGTYPE, "certified").equalsIgnoreCase("certified")) {
            if (cmd.getOptionValue(ConfigurationManager.OPTIONS_TRANSFORM_TYPE, "docmdp").equals("fieldmdp")) {
                FieldMDPSigner.sign(cmd, pdDocument, result, data -> SignUtils.signWithSeparatedHashing(data));
            } else {
                DocMDPSigner.sign(cmd, pdDocument, result, data -> SignUtils.signWithSeparatedHashing(data));
            }
        } else {
            ApprovalSigner.sign(cmd, pdDocument, result, data -> SignUtils.signWithSeparatedHashing(data));
        }
    }
}
