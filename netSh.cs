using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpSec
{
    class netSh
    {
        public static string command(string A_0)
        {
            string empty = string.Empty;
            try
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo("netsh", A_0);
                processStartInfo.RedirectStandardOutput = true;
                processStartInfo.UseShellExecute = false;
                processStartInfo.CreateNoWindow = true;
                Process process = new Process();
                process.StartInfo = processStartInfo;
                process.Start();
                process.WaitForExit();
                return process.StandardOutput.ReadToEnd().Trim().Replace("\r", "").Replace("\n", "");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
