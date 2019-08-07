package org.rub.nds.pdf.pdfsigner;

import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.security.KeyStore;
import java.security.KeyStoreException;
import java.security.NoSuchAlgorithmException;
import java.security.PrivateKey;
import java.security.Security;
import java.security.UnrecoverableKeyException;
import java.security.cert.Certificate;
import java.security.cert.CertificateException;
import org.apache.commons.cli.CommandLine;
import org.apache.commons.cli.CommandLineParser;
import org.apache.commons.cli.DefaultParser;
import org.apache.commons.cli.HelpFormatter;
import org.apache.commons.cli.Option;
import org.apache.commons.cli.Options;
import org.apache.commons.cli.ParseException;
import org.bouncycastle.jce.provider.BouncyCastleProvider;

/**
 *
 * @author vladi
 */
public class ConfigurationManager {

    public static String KEYSTORE = "demo-rsa2048.p12";
    public static char[] PASSWORD = "demo-rsa2048".toCharArray();

    public static final String OPTIONS_INPUT = "i";
    public static final String OPTIONS_OUTPUT = "o";
    public static final String OPTIONS_JKS = "jks";
    public static final String OPTIONS_PKCS = "pkcs";
    public static final String OPTIONS_PASSWORD = "p";
    public static final String OPTIONS_SIGTYPE = "sigtype";
    public static final String OPTIONS_SIGVIEW = "sigview";
    public static final String OPTIONS_PERMISSION = "perm";
    public static final String OPTIONS_LOCK = "lock";
    public static final String OPTIONS_SIG_IMG = "sigimg";
    public static final String OPTIONS_TRANSFORM_TYPE = "transform";
    public static final String OPTIONS_FIELDMDP_ACTION = "fieldmpd_action";
    public static final String OPTIONS_FIELDMDP_FIELDS = "fieldmpd_fields";
    
    public static KeyStore ks = null;
    public static PrivateKey pk = null;
    public static Certificate[] chain = null;

    public static CommandLine init(String[] args) throws KeyStoreException, FileNotFoundException, IOException, NoSuchAlgorithmException, CertificateException, UnrecoverableKeyException {
        CommandLine cmd = commandLineParserInit(args);
        initKeys(cmd);
        return cmd;
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
    
    
    private static CommandLine commandLineParserInit(String[] args) {
        Options options = new Options();
        inputFilesOptions(options);
        keyOtions(options);
        sigTypeOptions(options);
        fieldMDPOptions(options);
        sigViewOptions(options);

        CommandLineParser parser = new DefaultParser();
        HelpFormatter formatter = new HelpFormatter();
        CommandLine cmd;

        try {
            cmd = parser.parse(options, args);
            return cmd;
        } catch (ParseException e) {
            System.out.println(e.getMessage());
            formatter.printHelp("PDFSigner", options);
            System.exit(1);
            return null;
        }
    }

    private static void sigViewOptions(Options options) throws IllegalArgumentException {
        Option sigimg = new Option(OPTIONS_SIG_IMG, true, "Image path to visible signature");
        sigimg.setArgName("png | jpg");
        sigimg.setRequired(false);
        options.addOption(sigimg);
        
        Option sigview = new Option(OPTIONS_SIGVIEW, true, "Signature view");
        sigview.setArgName("visible(default) | invisible");
        sigview.setRequired(false);
        options.addOption(sigview);
    }

    private static void fieldMDPOptions(Options options) throws IllegalArgumentException {
        
        Option fieldMPDAction = new Option(OPTIONS_FIELDMDP_ACTION, true, "Specifies which fields are protected by the signature");
        fieldMPDAction.setArgName("all(default) | include | exclude");
        fieldMPDAction.setRequired(false);
        options.addOption(fieldMPDAction);
        
        Option fieldMPDfields = new Option(OPTIONS_FIELDMDP_FIELDS, true, "Comma separated list of the field names included/excluded into the FielDMP computation");
        fieldMPDfields.setArgName("fieldname1,fieldname2,...");
        fieldMPDfields.setRequired(false);
        options.addOption(fieldMPDfields);
    }

    private static void sigTypeOptions(Options options) throws IllegalArgumentException {
        Option signatureType = new Option(OPTIONS_SIGTYPE, true, "Signature Type");
        signatureType.setArgName("certified(default) | approval");
        signatureType.setRequired(false);
        options.addOption(signatureType);
        
        Option transformType = new Option(OPTIONS_TRANSFORM_TYPE, true, "Signature Tranformation");
        transformType.setArgName("docmdp(default) | fieldmdp | ur3");
        transformType.setRequired(false);
        options.addOption(transformType);
        
        Option lockPDF = new Option(OPTIONS_LOCK, true, "Lock PDF: true/false (default)");
        lockPDF.setArgName("false(default) | true");
        lockPDF.setRequired(false);
        options.addOption(lockPDF);
        
        Option transformParam = new Option(OPTIONS_PERMISSION, true, "Transformation Parameter");
        transformParam.setArgName("2(default) | 1 | 3");
        transformParam.setRequired(false);
        options.addOption(transformParam);
        
    }

    private static void inputFilesOptions(Options options) throws IllegalArgumentException {

        Option inputFile = new Option(OPTIONS_INPUT, "input", true, "Path and Name of the PDF which will be signed");
        inputFile.setArgName("PDF filepath+filename");
        inputFile.setRequired(true);
        options.addOption(inputFile);
        
        Option outputFile = new Option(OPTIONS_OUTPUT, "output", true, "Path and Name of the signed PDF");
        outputFile.setArgName("PDF filepath+filename");
        outputFile.setRequired(true);
        options.addOption(outputFile);
    }

    private static void keyOtions(Options options) throws IllegalArgumentException {
        Option jksFile = new Option(OPTIONS_JKS, "jksFile", true, "JavaKeyStore file");
        jksFile.setArgName("JKS filepath+filename");
        jksFile.setRequired(false);
        options.addOption(jksFile);
        
        Option pkcs12File = new Option(OPTIONS_PKCS, "pkcsFile", true, "PKCS12 file");
        pkcs12File.setRequired(false);
        pkcs12File.setArgName("PKCS12 filepath+filename");
        options.addOption(pkcs12File);
        
        Option password = new Option(OPTIONS_PASSWORD, "password", true, "JKS/PKCS12 password to access the private keys");
        password.setArgName("password");
        password.setRequired(false);
        options.addOption(password);
    }
}
