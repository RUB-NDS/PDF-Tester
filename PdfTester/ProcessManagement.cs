//Quellen:
//https://docs.microsoft.com/de-de/dotnet/api/system.diagnostics.process.start?view=netframework-4.8
//Microsoft Corporation, abgerufen am 13.05.2019

using System;
using System.Diagnostics;

namespace PdfCertTester
{
    class ProcessManagement
    {
        public string processStart(string filename, string argument)
        {
            try
            {
                using (Process proc = new Process())
                {
                    proc.StartInfo.UseShellExecute = false;

                    //Verhindere Aufforderung zur Dokumentenwiederherstellung in LibreOffice
                    if (filename.Contains("sdraw.exe"))
                        argument = "--norestore " + "\"" + argument + "\"";
                    else
                        argument = "\"" + argument + "\"";

                    proc.StartInfo.FileName = filename;
                    proc.StartInfo.Arguments = argument;
                    proc.Start();
                    return proc.Id.ToString();
                }
            }
            catch (Exception e)
            {
                return "Fehler (ProcessManagement.processStart):" + Environment.NewLine + filename + Environment.NewLine + argument  + Environment.NewLine + e.ToString();
            }
        }

        public string processStop(int processId)
        {
            try
            {
                Process proc = Process.GetProcessById(processId);
                proc.Kill();

                //Kill soffice.bin from LibreOffice
                Process[] binProc = Process.GetProcessesByName("soffice.bin");
                if (binProc.Length > 0)
                    binProc[0].Kill();

                return "ok";
            }
            catch (Exception e)
            {
                return "Fehler (ProcessManagement.processStop):" + Environment.NewLine + e.ToString();
            }
        }
    }
}
