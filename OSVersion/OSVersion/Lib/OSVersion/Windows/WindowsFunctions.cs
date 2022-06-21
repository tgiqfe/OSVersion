﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Runtime.InteropServices;
using OSVersion.Lib.OSVersion.Any;

namespace OSVersion.Lib.OSVersion.Windows
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    internal class WindowsFunctions
    {
        #region Check ServerOS

        [DllImport("shlwapi.dll", SetLastError = true, EntryPoint = "#437")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsOS(uint os);

        //  OSType
        //  参考
        //  https://www.pinvoke.net/default.aspx/shlwapi.isos

        //private const uint OS_Windows = 0;
        //private const uint OS_NT = 1;
        //private const uint OS_Win95OrGreater = 2;
        //private const uint OS_NT4OrGreater = 3;
        //private const uint OS_Win98OrGreater = 5;
        //private const uint OS_Win98Gold = 6;
        //private const uint OS_Win2000OrGreater = 7;
        //private const uint OS_Win2000Pro = 8;
        //private const uint OS_Win2000Server = 9;
        //private const uint OS_Win2000AdvancedServer = 10;
        //private const uint OS_Win2000DataCenter = 11;
        //private const uint OS_Win2000Terminal = 12;
        //private const uint OS_Embedded = 13;
        //private const uint OS_TerminalClient = 14;
        //private const uint OS_TerminalRemoteAdmin = 15;
        //private const uint OS_Win95Gold = 16;
        //private const uint OS_MEOrGreater = 17;
        //private const uint OS_XPOrGreater = 18;
        //private const uint OS_Home = 19;
        //private const uint OS_Professional = 20;
        //private const uint OS_DataCenter = 21;
        //private const uint OS_AdvancedServer = 22;
        //private const uint OS_Server = 23;
        //private const uint OS_TerminalServer = 24;
        //private const uint OS_PersonalTerminalServer = 25;
        //private const uint OS_FastUserSwitching = 26;
        //private const uint OS_WelcomeLogonUI = 27;
        //private const uint OS_DomainMember = 28;
        private const uint OS_AnyServer = 29;
        //private const uint OS_WOW6432 = 30;
        //private const uint OS_WebServer = 31;
        //private const uint OS_SmallBusinessServer = 32;
        //private const uint OS_TabletPC = 33;
        //private const uint OS_ServerAdminUI = 34;
        //private const uint OS_MediaCenter = 35;
        //private const uint OS_Appliance = 36;

        public static bool IsWindowsServer()
        {
            return IsOS(OS_AnyServer);
        }

        #endregion

        public static WindowsOS GetCurrent(OSCollection collection)
        {
            var mo = new ManagementClass("Win32_OperatingSystem").
                GetInstances().
                OfType<ManagementObject>().
                First();
            string caption = mo["Caption"]?.ToString();
            string editionText = caption.Split(" ").Last();

            bool isServer = IsOS(OS_AnyServer);
            string osName = caption switch
            {
                string s when s.StartsWith("Microsoft Windows 10") => "Windows 10",
                string s when s.StartsWith("Microsoft Windows 11") => "Windows 11",
                string s when s.StartsWith("Microsoft Windows Server") => "Windows Server",
                _ => null,
            };
            var winOS = collection.
                Where(x => x.OSFamily == OSFamily.Windows && (x.ServerOS ?? false) == isServer && x.Name == osName).
                FirstOrDefault(x => x.VersionName == (mo["Version"]?.ToString() ?? ""));
            winOS.Edition = Enum.TryParse(editionText, out Edition tempEdition) ? tempEdition : Edition.None;

            if (winOS.GetType().IsSubclassOf(typeof(OSInfo)))
            {
                Console.WriteLine("sabu");
            }


            return winOS as WindowsOS;
        }


        private class WindowsOSRange
        {
            public OSInfo[] Minimum { get; set; }
            public OSInfo[] Maximum { get; set; }
            public WindowsOSRange(OSCollection collection, string text)
            {
                string[] osWord = text.Contains("~") ?
                    new[] { text.Substring(0, text.IndexOf("~")), text.Substring(text.IndexOf("~") + 1) } :
                    new[] { text, text };
                this.Minimum = string.IsNullOrEmpty(osWord[0]) ?
                    new OSInfo[] { AnyOS.CreateMinimum() } :
                    collection.Where(x => x.IsMatch(osWord[0])).ToArray();
                this.Maximum = string.IsNullOrEmpty(osWord[1]) ?
                    new OSInfo[] { AnyOS.CreateMaximum() } :
                    collection.Where(x => x.IsMatch(osWord[1])).ToArray();
            }
            public bool Within(WindowsOS current)
            {
                bool minRet = Minimum.Where(x => x.OSFamily == OSFamily.Any || x.Name == current.Name).
                    Any(x => x <= current);
                bool maxRet = Maximum.Where(x => x.OSFamily == OSFamily.Any || x.Name == current.Name).
                    Any(x => x >= current);

                return minRet && maxRet;
            }
        }

        public static bool WithinOS(OSCollection collection, WindowsOS current, string text)
        {
            var list = new List<WindowsOSRange>();
            foreach (string field in text.Split(","))
            {
                list.Add(new WindowsOSRange(collection, field));
            }
            return list.Any(x => x.Within(current));
        }
    }
}
