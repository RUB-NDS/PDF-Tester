using System;
using System.IO;

namespace PdfCertTester
{
    class Config
    {
        private string path;
        public Config(string path)
        {
            this.path = path;
        }

        // Erstelle Ordner und Konfigurationsdatei, falls nicht vorhanden
        public string createConfig(string filename)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    if (!File.Exists(path + filename))
                    {
                        File.Create(path + filename).Close();
                    }
                }
                else
                {
                    Directory.CreateDirectory(path);
                    File.Create(path + filename).Close();
                }
            }
            catch (Exception e)
            {
                return "Fehler 102 (Control.createConfig):" + Environment.NewLine + e.ToString();
            }
            return "ok";
        }

        // Lese die Konfigurationsdateien ein
        public string readConfig(string filename)
        {
            string str = "";
            try
            {
                using (StreamReader sr = new StreamReader(path + filename))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        str += line + "\r\n";
                    }
                }
            }
            catch (Exception e)
            {
                return "Fehler 103 (Control.readConfig):" + Environment.NewLine + e.ToString();
            }
            return str;
        }

        // Speichere die gemachten Eingaben ab
        public string writeConfig(string content, string filename)
        {
            try
            {
                using (StreamWriter sw = File.CreateText(path + filename))
                {
                    sw.WriteLine(content);
                }
            }
            catch (Exception e)
            {
                return "Fehler 104 (Control.writeConfig):" + Environment.NewLine + e.ToString();
            }
            return "ok";
        }



    }
}
