using System;
using System.IO;

namespace PdfCertTester
{
    class Debug
    {
        private string path;
        private string filename;
        public Debug(string path, string filename)
        {
            this.path = path;
            this.filename = filename;
        }

        public string createDebug()
        {
            try
            {
                if (Directory.Exists(path))
                {
                    if (!File.Exists(path + filename))
                        File.Create(path + filename).Close();
                }
                else
                {
                    Directory.CreateDirectory(path);
                    File.Create(path + filename).Close();
                }
            }
            catch (Exception e)
            {
                return "Fehler (Debug.createDebugFile):" + Environment.NewLine + e.ToString();
            }
            return "ok";
        }

        public string writeDebug(string text)
        {
            try
            {
                using (StreamWriter sw = File.CreateText(path + filename))
                {
                    sw.WriteLine(DateTime.Now + Environment.NewLine + text + Environment.NewLine);
                }
            }
            catch (Exception e)
            {
                return "Fehler (Debug.writeDebug):" + Environment.NewLine + e.ToString();
            }
            return "ok";
        }

    }
}
