using System;
using System.IO;

namespace PdfTester
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
                return "Fehler (Control.createConfig):" + Environment.NewLine + e.ToString();
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
                return "Fehler (Control.readConfig):" + Environment.NewLine + e.ToString();
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
                return "Fehler (Control.writeConfig):" + Environment.NewLine + e.ToString();
            }
            return "ok";
        }

        public string writeText(string content, string filename)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filename, true))
                {

                    sw.WriteLine(content);
                    sw.WriteLine();
                }
            }
            catch (Exception e)
            {
                return "Fehler (Control.writeText):" + Environment.NewLine + e.ToString();
            }
            return "ok";
        }



    }
}
