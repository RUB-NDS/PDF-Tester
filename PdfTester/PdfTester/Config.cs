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

        //Create directory and configuration file, if not existing
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
                return "Error (Control.createConfig):" + Environment.NewLine + e.ToString();
            }
            return "ok";
        }

        //Read configuration files
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
                return "Error (Control.readConfig):" + Environment.NewLine + e.ToString();
            }
            return str;
        }

        //Save the made entries
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
                return "Error (Control.writeConfig):" + Environment.NewLine + e.ToString();
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
                return "Error (Control.writeText):" + Environment.NewLine + e.ToString();
            }
            return "ok";
        }
    }
}
