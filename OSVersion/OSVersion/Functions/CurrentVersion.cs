using System.Management;
using System.Runtime.Versioning;
using System.Text;

namespace OSVersion.Functions
{
    [SupportedOSPlatform("windows")]
    public class CurrentVersion
    {
        public static (string, string, string, string, bool) GetCurrent()
        {
            string caption = "";
            string edition = "";
            string version = "";

            try
            {
                //  ManagementClassが使用できる場合
                var mo = new ManagementClass("Win32_OperatingSystem").
                    GetInstances().
                    OfType<ManagementObject>().
                    First();
                caption = mo["Caption"]?.ToString();
                edition = caption.Split(" ").Last();
                version = mo["Version"]?.ToString() ?? "";
            }
            catch
            {
                //  ManagementClassが使用できない場合
                var outTexts = CommandOutput(
                    "powershell", "-Command \"$os = @(Get-CimInstance Win32_OperatingSystem); $os.Caption; $os.Version\"").ToArray();
                caption = outTexts[0];
                edition = caption.Split(" ").Last();
                version = outTexts[1];
            }

            string osName = caption switch
            {
                string s when s.StartsWith("Microsoft Windows 10") => "Windows 10",
                string s when s.StartsWith("Microsoft Windows 11") => "Windows 11",
                string s when s.StartsWith("Microsoft Windows Server") => "Windows Server",
                _ => null,
            };
            bool isServer = WindowsServer.Check();

            return (osName, caption, edition, version, isServer);
        }

        /// <summary>
        /// コマンド実行結果を取得
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
    }
}
