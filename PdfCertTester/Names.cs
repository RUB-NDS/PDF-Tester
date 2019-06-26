using System;

namespace PdfCertTester
{
    static class Names
    {
        public static string path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\PdfTester\\";
        public static string debugFilename = "debug.txt";
        public static string programListFilename = "programList.conf";
        public static string pdfPathFilename = "pdfPath.conf";
        public static string screenshotPathFilename = "screenshotPath.conf";
        public static string pdfValidPathFilename = "pdfValidPath.conf";
        public static string settingsFilename = "settings.conf";
        public static string waitTime1 = "50";
        public static string waitTime2 = "2";
        public static string diffValue = "0,00001";
        public static string error = "Fehler";
        public static string info = "Hinweis";
        public static string pdfFilename = @"\PDF-Tester-Dokument.pdf";
        public static string pdfFilenameNew = @"\PDF-Tester-Dokument_" + DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".pdf";
        public static string libreOfficeLockFile = @"\.~lock.PDF-Tester-Dokument.pdf#";
        public static string editor = @"C:\Windows\System32\notepad.exe";
        public static int maxHeight = 500;
    }
}
