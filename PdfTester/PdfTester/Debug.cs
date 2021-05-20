using System;
using System.IO;

namespace PdfTester
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
                return "Error (Debug.createDebugFile):" + Environment.NewLine + e.ToString();
            }
            return "ok";
        }

        public string writeDebug(string text)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path + filename, true))
                {
                    sw.WriteLine(DateTime.Now + Environment.NewLine + text + Environment.NewLine);
                }
            }
            catch (Exception e)
            {
                return "Error (Debug.writeDebug):" + Environment.NewLine + e.ToString();
            }
            return "ok";
        }

    }
}
