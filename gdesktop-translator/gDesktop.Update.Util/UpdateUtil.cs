using System;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace gDesktop.Update.Util
{
    class UpdateUtil
    {
        
        
        static void Main(string[] args)
        {
            CloseGTranslator();
            Console.WriteLine("Updating files...");
            String batFile = Path.Combine(Environment.CurrentDirectory, "update.bat");
            Console.WriteLine(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            Console.WriteLine("---");
            Console.WriteLine(System.Reflection.Assembly.GetExecutingAssembly().Location);
            Console.WriteLine("---");
            Console.WriteLine("Executing "+batFile);
            ExecuteCommand("\""+batFile+"\" >>update.log");
            Console.WriteLine("Update complete");
            string exeFile = Path.Combine(Environment.CurrentDirectory, "gDesktopTranslator.exe");
            Console.WriteLine(exeFile);
            System.Diagnostics.Process.Start(exeFile);
        }

        public static int ExecuteCommand(string Command)
        {
            int ExitCode;
            ProcessStartInfo ProcessInfo;
            Process Process;

            ProcessInfo = new ProcessStartInfo("cmd.exe", "/C " + Command);
            ProcessInfo.CreateNoWindow = false;
            ProcessInfo.UseShellExecute = false;
            Process = Process.Start(ProcessInfo);
            Process.WaitForExit();
            ExitCode = Process.ExitCode;
            Process.Close();

            return ExitCode;
        }

        private static void CloseGTranslator()
        {
            Process[] processes;
            string procName = "gDesktopTranslator";
            processes = Process.GetProcessesByName(procName);
            foreach (Process proc in processes)
            {
                Console.WriteLine("Closing process "+proc.ProcessName+" with ID "+proc.Id);
                proc.CloseMainWindow();
                proc.WaitForExit();
            }
   

        }
    }
}
