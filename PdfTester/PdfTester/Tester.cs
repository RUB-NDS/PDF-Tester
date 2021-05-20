//References:
//https://social.technet.microsoft.com/wiki/contents/articles/26805.c-calculating-percentage-similarity-of-2-strings.aspx
//Microsoft Corporation

using System;
using System.Drawing;


namespace PdfTester
{
    class Tester
    {
        public string compare(string image1, string image2, string maxHeight)
        {
            try
            {
                Bitmap img1 = new Bitmap(image1);
                Bitmap img2 = new Bitmap(image2);
                int intMaxHeight = 0;

                try
                {
                    intMaxHeight = Convert.ToInt32(maxHeight);
                }
                catch (Exception e)
                {
                    return "Error while converting maxHeight: '" + maxHeight + "' (Tester.compare):" + Environment.NewLine + e.ToString();
                }

                if (img1.Height < intMaxHeight || img2.Height < intMaxHeight)
                {
                    if (img1.Height <= img2.Height)
                        intMaxHeight = img1.Height;
                    else if (img1.Height > img2.Height)
                        intMaxHeight = img2.Height;
                }

                if (img1.Width != img2.Width)
                {
                    return "Error: Screenshots must have the same width.";
                }
                else
                {

                    double diff = 0;

                    for (int y = 0; y < intMaxHeight; y++)
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
                    string result = (100 * (diff / 255) / (img1.Width * intMaxHeight * 3)).ToString();
                    return result;
                }
            }
            catch (Exception e)
            {
                return "Fehler (Tester.compare):" + Environment.NewLine + e.ToString();
            }
        }
    }
}
