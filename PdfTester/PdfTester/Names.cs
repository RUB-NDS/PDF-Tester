using System;

namespace PdfTester
{
    static class Names
    {
        public static string path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\PdfTester\\";
        public static string debugFilename = "debug.txt";
        public static string programListFilename = "programList.conf";
        public static string pdfPathFilename = "pdfPath.conf";
        public static string screenshotPathStartFilename = "screenshotPathStart.conf";
        public static string screenshotPathCompareFilename = "screenshotPathCompare.conf";
        public static string screenshotPathValidFilename = "screenshotPathValid.conf";
        public static string screenshotPathOcrFilename = "screenshotPathOcr.conf";
        public static string txtPathFilename = "txtPath.conf";
        public static string searchStringsFilename = "searchStrings.conf";
        public static string tesseractPathFilename = "tesseractPath.conf";
        public static string settingsFilename = "settings.conf";
        public static string ocrFilename = "ocr.conf";
        public static string waitTime1 = "50";
        public static string waitTime2 = "2";
        public static string diffValue = "0,00001";
        public static string maxHeight = "500";
        public static string language = "eng";
        public static string error = "Error";
        public static string info = "Note";
        public static string pdfFilename = @"\PDF-Tester-document.pdf";
        public static string libreOfficeLockFile = @"\.~lock.PDF-Tester-document.pdf#";
        public static string editor = @"C:\Windows\System32\notepad.exe";
        public static string tessdata = "./tessdata";
    }
}
