//References:
//https://docs.microsoft.com/de-de/dotnet/api/system.diagnostics.process.start?view=netframework-4.8
//Microsoft Corporation

using System;
using System.Diagnostics;

namespace PdfTester
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

                    //Prevent document restore prompt in LibreOffice
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
                return "Error (ProcessManagement.processStart):" + Environment.NewLine + filename + Environment.NewLine + argument  + Environment.NewLine + e.ToString();
            }
        }

        public string processStop(int processId)
        {
            try
            {

                Process proc = Process.GetProcessById(processId);
                proc.Kill();

                //Kill soffice.bin from LibreOffice
                foreach (var process in Process.GetProcessesByName("soffice.bin"))
                {
                    process.Kill();
                }

                //Kill architect.exe from PDF Architect
                foreach (var process in Process.GetProcessesByName("architect.exe"))
                {
                    process.Kill();
                }

                //Kill expert.exe from Expert PDF
                foreach (var process in Process.GetProcessesByName("expert.exe"))
                {
                    process.Kill();
                }

                return "ok";
            }
            catch (Exception e)
            {
                return "Fehler (ProcessManagement.processStop):" + Environment.NewLine + e.ToString();
            }
        }
    }
}
