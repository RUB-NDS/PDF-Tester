using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;

namespace PdfTester
{
    class Tesseract
    {
        public string startOcr(string tesseractPath, string image, string language, Boolean large)
        {
            string result = "";
            var tmpResultText = Path.GetTempPath() + Guid.NewGuid();
            var tmpImg = Path.GetTempFileName();

            string dic = "";
            try
            {
                if (large == true)
                {
                    Bitmap tmpImage = new Bitmap(image);

                    //Auflösung zur besseren OCR-Erkennung auf Pixelbreite von ca. 6000 erhöhen
                    //Multiplikator abgestimmt auf Pixelbreite: 1366, 1600, 1920, 2560, 3200, 3440, 3840
                    int width = 0, height = 0;

                    if (tmpImage.Width < 1400)
                    {
                        width = (int)(tmpImage.Width * 4.4);
                        height = (int)(tmpImage.Height * 4.4);
                    }
                    else if (tmpImage.Width >= 1400 && tmpImage.Width < 1900)
                    {
                        width = (int)(tmpImage.Width * 3.75);
                        height = (int)(tmpImage.Height * 3.75);
                    }
                    else if (tmpImage.Width >= 1900 && tmpImage.Width < 2500)
                    {
                        width = (int)(tmpImage.Width * 3.15);
                        height = (int)(tmpImage.Height * 3.15);
                    }
                    else if (tmpImage.Width >= 2500 && tmpImage.Width < 3100)
                    {
                        width = (int)(tmpImage.Width * 2.35);
                        height = (int)(tmpImage.Height * 2.35);
                    }
                    else if (tmpImage.Width >= 3100 && tmpImage.Width < 3400)
                    {
                        width = (int)(tmpImage.Width * 1.9);
                        height = (int)(tmpImage.Height * 1.9);
                    }
                    else if (tmpImage.Width >= 3000 && tmpImage.Width < 3500)
                    {
                        width = (int)(tmpImage.Width * 1.75);
                        height = (int)(tmpImage.Height * 1.75);
                    }
                    else if (tmpImage.Width >= 3500 && tmpImage.Width < 4000)
                    {
                        width = (int)(tmpImage.Width * 1.6);
                        height = (int)(tmpImage.Height * 1.6);
                    }
                    else if (tmpImage.Width >= 4000 && tmpImage.Width < 4500)
                    {
                        width = (int)(tmpImage.Width * 1.5);
                        height = (int)(tmpImage.Height * 1.5);
                    }
                    else if (tmpImage.Width >= 4500 && tmpImage.Width < 5000)
                    {
                        width = (int)(tmpImage.Width * 1.35);
                        height = (int)(tmpImage.Height * 1.35);
                    }
                    else if (tmpImage.Width >= 5000 && tmpImage.Width < 5500)
                    {
                        width = (int)(tmpImage.Width * 1.2);
                        height = (int)(tmpImage.Height * 1.2);
                    }
                    else if (tmpImage.Width >= 5500 && tmpImage.Width < 6000)
                    {
                        width = (int)(tmpImage.Width * 1.1);
                        height = (int)(tmpImage.Height * 1.1);
                    }
                    else
                    {
                        width = tmpImage.Width;
                        height = tmpImage.Height;
                    }

                    Bitmap imgLarge = new Bitmap(tmpImage, new Size(width, height));
                    
                    using (MemoryStream stream = new MemoryStream())
                    {
                        imgLarge.Save(stream, ImageFormat.Bmp);
                        File.WriteAllBytes(tmpImg, stream.ToArray());
                    }
                }
                else
                {
                    var imageByte = File.ReadAllBytes(image);
                    File.WriteAllBytes(tmpImg, imageByte);
                }

                using (Process proc = new Process())
                {
                    proc.StartInfo.WorkingDirectory = tesseractPath;
                    proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    proc.StartInfo.CreateNoWindow = true;
                    proc.StartInfo.UseShellExecute = false;
                    proc.StartInfo.FileName = "cmd.exe";
                    proc.StartInfo.Arguments = "/c tesseract.exe " + tmpImg + " " + tmpResultText + " -l " + language;
                    proc.Start();
                    proc.WaitForExit();
                    if (proc.ExitCode == 0)
                    {
                        using (StreamReader sr = new StreamReader(tmpResultText + ".txt"))
                        {
                            string line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                if (line.Trim() != "")
                                    result += line + "\r\n";
                            }
                        }
                    }
                    else
                        result = "Fehler bei Verarbeitung mit tesseract.exe." + Environment.NewLine + "Status: " + proc.ExitCode;
                }
            }
            catch (Exception e)
            {
                result = "Fehler (Tesseract.startOcr):" + tesseractPath + Environment.NewLine + dic + Environment.NewLine + e.ToString();
            }

            File.Delete(tmpResultText + ".txt");
            File.Delete(tmpImg);

            return result;
        }
    }
}
