using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace OSVersion.Lib
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    internal class WindowsOSCollection : List<WindowsOS>
    {
        const string dbFileName = "windowsOSCollection.json";

        public void LoadDefault()
        {
            //  Windowos 10
            this.Add(Windows10.Create1507());
            this.Add(Windows10.Create1607());
            this.Add(Windows10.Create1703());
            this.Add(Windows10.Create1709());
            this.Add(Windows10.Create1803());
            this.Add(Windows10.Create1809());
            this.Add(Windows10.Create1903());
            this.Add(Windows10.Create1909());
            this.Add(Windows10.Create2004());
            this.Add(Windows10.Create20H2());
            this.Add(Windows10.Create21H1());
            this.Add(Windows10.Create21H2());

            //  Windows 11
            this.Add(Windows11.Create21H2());

            //  Windows Server
            this.Add(WindowsServer.Create2012());
            this.Add(WindowsServer.Create2012R2());
            this.Add(WindowsServer.Create2016());
            this.Add(WindowsServer.Create2019());
            this.Add(WindowsServer.Create2022());
        }

        #region Load/Save

        /// <summary>
        /// DBファイルからロード。
        /// もしDBファイルの読み込みに失敗した場合は、デフォルト値でロードして上書き保存。
        /// </summary>
        /// <param name="dbDirectory"></param>
        /// <returns></returns>
        public static WindowsOSCollection Load(string dbDirectory)
        {
            WindowsOSCollection result = null;
            try
            {
                string dbPath = Path.Combine(dbDirectory, dbFileName);
                using (var sr = new StreamReader(dbPath, Encoding.UTF8))
                {
                    result = JsonSerializer.Deserialize<WindowsOSCollection>(sr.ReadToEnd(), new JsonSerializerOptions()
                    {
                        //Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                        IgnoreReadOnlyProperties = true,
                        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
                        WriteIndented = true,
                        Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter(System.Text.Json.JsonNamingPolicy.CamelCase) },
                    });
                }
            }
            catch { }
            if (result == null)
            {
                result = new WindowsOSCollection();
                result.LoadDefault();
                result.Save(dbDirectory);
            }
            return result;
        }

        /// <summary>
        /// DBファイルを保存
        /// </summary>
        /// <param name="dbDirectory"></param>
        public void Save(string dbDirectory)
        {
            string dbPath = Path.Combine(dbDirectory, dbFileName);
            if (!Directory.Exists(dbDirectory))
            {
                Directory.CreateDirectory(dbDirectory);
            }
            using (var sw = new StreamWriter(dbPath, false, Encoding.UTF8))
            {
                string json = JsonSerializer.Serialize(this, new JsonSerializerOptions()
                {
                    //Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    IgnoreReadOnlyProperties = true,
                    DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
                    WriteIndented = true,
                    Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter(System.Text.Json.JsonNamingPolicy.CamelCase) },
                });
                sw.WriteLine(json);
            }
        }

        #endregion

        public List<WindowsOS> GetMatchOS(string keyword)
        {
            var list = new List<WindowsOS>();
            list.AddRange(this.Where(x => x.VersionName == keyword));
            list.AddRange(this.Where(x => x.VersionAlias.Any(y => y.Equals(keyword, StringComparison.OrdinalIgnoreCase))));
            list.AddRange(
                this.Where(x => keyword.StartsWith(x.Name, StringComparison.OrdinalIgnoreCase) ||
                    x.Alias.Any(y => keyword.StartsWith(y, StringComparison.OrdinalIgnoreCase))).
                    Where(x => keyword.EndsWith(x.VersionName, StringComparison.OrdinalIgnoreCase) ||
                    x.VersionAlias.Any(y => keyword.EndsWith(y, StringComparison.OrdinalIgnoreCase))));

            return list;
        }
    }
}
