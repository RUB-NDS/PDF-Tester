//Quellen:
//https://docs.microsoft.com/de-de/dotnet/api/system.drawing?view=netframework-4.8
//Microsoft Corporation, abgerufen am 13.05.2019
//
//https://docs.microsoft.com/de-de/dotnet/api/system.windows.systemparameters?view=netframework-4.8
//Microsoft Corporation, abgerufen am 13.05.2019

using System;
using System.Windows;
using System.Drawing;

namespace PdfCertTester
{
    class Screenshot
    {

        public string makeScreenshot(string path)
        {
            try
            {
                int screenWidth = Convert.ToInt32(SystemParameters.FullPrimaryScreenWidth);
                int screenHeight = Convert.ToInt32(SystemParameters.FullPrimaryScreenHeight);

                Bitmap image = new Bitmap(screenWidth, screenHeight);
                Size s = new Size(image.Width, image.Height);

                Graphics shot = Graphics.FromImage(image);
                shot.CopyFromScreen(0, 0, 0, 0, s);

                image.Save(path);
            }
            catch (Exception e)
            {
                return "Fehler (Screenshot.makeScreenshot):" + Environment.NewLine + e.ToString();
            }
            return "ok";

        }
    }
}
