using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Runtime.InteropServices;

namespace OSVersion.Lib.OSVersion.Windows
{
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

        private static OSCollection _collection = null;

        #region GetCurrent

        /// <summary>
        /// 事前ロード済みOSCollectionインスタンスを使用しない場合のGetCurrent
        /// </summary>
        /// <returns></returns>
        public static OSInfo GetCurrent()
        {
            _collection ??= OSCollection.Create();
            return GetCurrent(_collection);
        }

        public static OSInfo GetCurrent(OSCollection collection)
        {
            string caption = "";
            string editionText = "";
            string version = "";
            try
            {
                //  ManagementClassが使用できる場合
                var mo = new ManagementClass("Win32_OperatingSystem").
                    GetInstances().
                    OfType<ManagementObject>().
                    First();
                caption = mo["Caption"]?.ToString();
                editionText = caption.Split(" ").Last();
                version = mo["Version"]?.ToString() ?? "";
            }
            catch
            {
                //  ManagementClassが使用できない場合
                var outTexts = CommandOutput(
                    "powershell", "-Command \"$os = @(Get-CimInstance Win32_OperatingSystem); $os.Caption; $os.Version\"").ToArray();
                caption = outTexts[0];
                editionText = caption.Split(" ").Last();
                version = outTexts[1];
            }

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
                FirstOrDefault(x => x.VersionName == version);
            winOS.Edition = Enum.TryParse(editionText, out Edition tempEdition) ? tempEdition : Edition.None;

            return winOS;
        }

        /// <summary>
        /// ManagementClass使用時に失敗する場合、外部コマンドから情報を収集
        /// (.NET Framework 4.8のバージョンが低い、等)
        /// </summary>
        /// <param name="command"></param>
        /// <param name="arguments"></param>
        /// <param name="containsError"></param>
        /// <returns></returns>
        private static IEnumerable<string> CommandOutput(string command, string arguments, bool containsError = false)
        {
            var sb = new StringBuilder();

            using (var proc = new System.Diagnostics.Process())
            {
                proc.StartInfo.FileName = command;
                proc.StartInfo.Arguments = arguments;
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.RedirectStandardInput = false;
                proc.OutputDataReceived += (sender, e) => { sb.AppendLine(e.Data); };
                if (containsError) proc.ErrorDataReceived += (sender, e) => { sb.AppendLine(e.Data); };
                proc.Start();
                proc.BeginOutputReadLine();
                if (containsError) proc.BeginErrorReadLine();
                proc.WaitForExit();
            }

            return System.Text.RegularExpressions.Regex.Split(sb.ToString(), @"\r?\n").
                Select(x => x.Trim()).
                Where(x => !string.IsNullOrEmpty(x));
        }

        #endregion
        #region Within

        /// <summary>
        /// 事前ロード済みOSCollectionインスタンスを使用しない場合のWithin
        /// </summary>
        /// <param name="current"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool WithinOS(OSInfo current, string text)
        {
            _collection ??= OSCollection.Create();
            return WithinOS(_collection, current, text);
        }

        public static bool WithinOS(OSCollection collection, OSInfo current, string text)
        {
            var list = new List<WindowsOSRange>();
            foreach (string field in text.Split(",").Select(x => x.Trim()))
            {
                list.Add(new WindowsOSRange(collection, field));
            }
            return list.Any(x => x.Within(current));
        }

        #endregion
        #region From Keyword

        public static OSInfo FromKeyword(string keyword)
        {
            _collection ??= OSCollection.Create();
            return _collection.FirstOrDefault(x => x.IsMatch(keyword));
        }

        #endregion
    }
}
