//Quellen:
//https://social.technet.microsoft.com/wiki/contents/articles/26805.c-calculating-percentage-similarity-of-2-strings.aspx
//Microsoft Corporation, abgerufen am 04.06.2019

using System;
using System.Drawing;


namespace PdfCertTester
{
    class Tester
    {
        public string compare(string image1, string image2)
        {
            try
            {
                int maxHeight = Names.maxHeight;
                Bitmap img1 = new Bitmap(image1);
                Bitmap img2 = new Bitmap(image2);

                if (img1.Width != img2.Width)
                {
                    return "Fehler: Screenshots müssen die gleiche Breite besitzen.";
                }
                else if (img1.Height < maxHeight || img2.Height < maxHeight)
                {
                    return "Fehler: Screenshot besitzt nicht die Mindesthöhe von:" + maxHeight.ToString() + " Pixeln.";
                }
                else
                {

                    double diff = 0;

                    for (int y = 0; y < maxHeight; y++)
                    {
                        for (int x = 0; x < img1.Width; x++)
                        {
                            Color pixel1 = img1.GetPixel(x, y);
                            Color pixel2 = img2.GetPixel(x, y);

                            diff += Math.Abs(pixel1.R - pixel2.R);
                            diff += Math.Abs(pixel1.G - pixel2.G);
                            diff += Math.Abs(pixel1.B - pixel2.B);
                        }
                    }
                    string result = (100 * (diff / 255) / (img1.Width * maxHeight * 3)).ToString();
                    return result;
                }
            }
            catch (Exception e)
            {
                return "Fehler (Tester.compare):" + Environment.NewLine + e.ToString(); ;
            }
        }
    }
}
