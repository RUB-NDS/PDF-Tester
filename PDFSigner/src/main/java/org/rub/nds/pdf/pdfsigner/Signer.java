package org.rub.nds.pdf.pdfsigner;

import java.io.IOException;
import java.io.OutputStream;
import org.apache.commons.cli.CommandLine;
import org.apache.pdfbox.pdmodel.PDDocument;
import org.apache.pdfbox.pdmodel.interactive.digitalsignature.SignatureInterface;

/**
 *
 * @author vladi
 */
public interface Signer {
    public static void sign(CommandLine cmd, PDDocument document, OutputStream outputFile, SignatureInterface signatureInterface) throws IOException{}
}
