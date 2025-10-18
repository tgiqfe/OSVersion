using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OSVersion.OSVersions
{
    internal class OSVersions : List<OSVersion>
    {
        const string DEFAULT_PATH = "osversions.json";

        public void Init()
        {
            //  AnyOS
            Add(Builder.AnyOSBuilder.CreateMinimum());
            Add(Builder.AnyOSBuilder.CreateMaximum());

            //  Windows 10
            Add(Builder.WindowsBuilder.Create10ver1507());
            Add(Builder.WindowsBuilder.Create10ver1511());
            Add(Builder.WindowsBuilder.Create10ver1607());
            Add(Builder.WindowsBuilder.Create10ver1703());
            Add(Builder.WindowsBuilder.Create10ver1709());
            Add(Builder.WindowsBuilder.Create10ver1803());
            Add(Builder.WindowsBuilder.Create10ver1809());
            Add(Builder.WindowsBuilder.Create10ver1903());
            Add(Builder.WindowsBuilder.Create10ver1909());
            Add(Builder.WindowsBuilder.Create10ver2004());
            Add(Builder.WindowsBuilder.Create10ver20H2());
            Add(Builder.WindowsBuilder.Create10ver21H1());
            Add(Builder.WindowsBuilder.Create10ver21H2());
            Add(Builder.WindowsBuilder.Create10ver22H2());

            //  Windows 11
            Add(Builder.WindowsBuilder.Create11ver21H2());
            Add(Builder.WindowsBuilder.Create11ver22H2());
            Add(Builder.WindowsBuilder.Create11ver23H2());
            Add(Builder.WindowsBuilder.Create11ver24H2());
            Add(Builder.WindowsBuilder.Create11ver25H2());

            //  Windows Server
            Add(Builder.WindowsServerBuilder.Create2012());
            Add(Builder.WindowsServerBuilder.Create2012R2());
            Add(Builder.WindowsServerBuilder.Create2016());
            Add(Builder.WindowsServerBuilder.Create2019());
            Add(Builder.WindowsServerBuilder.Create2022());
            Add(Builder.WindowsServerBuilder.Create2025());
        }

        #region Load/Save

        /// <summary>
        /// Load from json file.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static OSVersions Load(string path = DEFAULT_PATH)
        {
            OSVersions collection = null;
            try
            {
                using (var sr = new StreamReader(path, Encoding.UTF8))
                {
                    collection = JsonSerializer.Deserialize<OSVersions>(sr.ReadToEnd(), new JsonSerializerOptions()
                    {
                        //Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                        IgnoreReadOnlyProperties = true,
                        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                        WriteIndented = true,
                        Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) },
                    });
                }
            }
            catch { }
            if (collection == null)
            {
                collection = new();
                collection.Init();
                collection.Save(path);
            }
            return collection;
        }

        /// <summary>
        /// Save to json file.
        /// </summary>
        /// <param name="path"></param>
        public void Save(string path = DEFAULT_PATH)
        {
            string parent = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(parent) && !Directory.Exists(parent))
            {
                Directory.CreateDirectory(parent);
            }
            try
            {
                using (var sw = new StreamWriter(path, false, Encoding.UTF8))
                {
                    string json = JsonSerializer.Serialize(this, new JsonSerializerOptions()
                    {
                        //Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                        IgnoreReadOnlyProperties = true,
                        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                        WriteIndented = true,
                        Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) },
                    });
                    sw.WriteLine(json);
                }
            }
            catch { }
        }

        #endregion
        #region Methods

        public OSVersion GetCurrent()
        {
            OSVersion osver = null;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                //  Windows OS
#pragma warning disable CA1416
                (var osName, var caption, var edition, var version, bool isServer) = Functions.WindowsFunctions.GetCurrent();
#pragma warning restore CA1416
                osver = this.
                    Where(x => x.OSFamily == OSFamily.Windows && (x.ServerOS ?? false) == isServer && x.Name == osName).
                    FirstOrDefault(x => x.VersionName == version);
                //osver.Edition = Enum.TryParse(edition, out Edition tempEdition) ? tempEdition : Edition.None;
                osver.Edition = EditionHelper.Parse(edition);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                //  Linux os
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                //  Mac os
            }
            return osver;
        }

        public static OSVersion GetCurrent(OSVersions osVersions = null)
        {
            osVersions ??= OSVersions.Load();
            return osVersions.GetCurrent();
        }

        public OSVersion FromKeyword(string keyword)
        {
            return this.FirstOrDefault(x => x.IsMatch(keyword));
        }

        public static OSVersion FromKeyword(string keyword, OSVersions osVersions = null)
        {
            osVersions ??= OSVersions.Load();
            return osVersions.FromKeyword(keyword);
        }

        public bool Within(string text, OSVersion current = null)
        {
            current ??= GetCurrent();

            var ranges = text.Split(",").Select(x => x.Trim()).Select(x =>
            {
                (string pre, string suf) = text.Contains("~") ?
                    (x.Substring(0, x.IndexOf("~")), x.Substring(x.IndexOf("~") + 1)) :
                    (x, x);
                var minumums = string.IsNullOrEmpty(pre) ?
                    new OSVersion[] { Builder.AnyOSBuilder.CreateMinimum() } :
                    this.Where(x => x.IsMatch(pre)).ToArray();
                var maximums = string.IsNullOrEmpty(suf) ?
                    new OSVersion[] { Builder.AnyOSBuilder.CreateMaximum() } :
                    this.Where(x => x.IsMatch(suf)).ToArray();
                return (minumums, maximums);
            });

            return ranges.Any(ranges =>
            {
                var ret_min = ranges.minumums.
                    Where(x => x.OSFamily == OSFamily.Any || x.Name == current.Name).
                    Any(x => x <= current);
                var ret_max = ranges.maximums.
                    Where(x => x.OSFamily == OSFamily.Any || x.Name == current.Name).
                    Any(x => x >= current);
                return ret_min && ret_max;
            });
        }

        public static bool Within(string text, OSVersion current = null, OSVersions osVersions = null)
        {
            osVersions ??= OSVersions.Load();
            return osVersions.Within(text, current);
        }

        #endregion
    }
}
