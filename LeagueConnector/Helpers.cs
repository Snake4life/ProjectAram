using System;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text.RegularExpressions;

namespace LeagueConnector
{
    public static class Helpers
    {
        public static Tuple<int, string> FindLcuParams(this Process process)
        {
            var authTokenRegex = new Regex("\"--remoting-auth-token=(.+?)\"");
            var portRegex = new Regex("\"--app-port=(\\d+?)\"");

            using (var mos = new ManagementObjectSearcher("SELECT CommandLine FROM Win32_Process WHERE ProcessId = " + process.Id))
            using (var moc = mos.Get())
            {
                var commandLine = (string)moc.OfType<ManagementObject>().First()["CommandLine"];
                return new Tuple<int, string>(int.Parse(portRegex.Match(commandLine).Groups[1].Value), authTokenRegex.Match(commandLine).Groups[1].Value);
            }
        }

        public static Process FindLcuProcess()
        {
            return Process.GetProcessesByName("LeagueClientUx").FirstOrDefault();
        }
    }
}