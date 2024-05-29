using OSVersion.Versions.Builder;
using OSVersion.Versions.Functions;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OSVersion.Versions
{
    internal class OSVersions : List<OSVersion>
    {
        const string DEFAULT_PATH = "osversions.json";

        public void Init()
        {
            //  AnyOS
            Add(AnyOSBuilder.CreateMinimum());
            Add(AnyOSBuilder.CreateMaximum());

            //  Windows 10
            Add(WindowsBuilder.Create10ver1507());
            Add(WindowsBuilder.Create10ver1511());
            Add(WindowsBuilder.Create10ver1607());
            Add(WindowsBuilder.Create10ver1703());
            Add(WindowsBuilder.Create10ver1709());
            Add(WindowsBuilder.Create10ver1803());
            Add(WindowsBuilder.Create10ver1809());
            Add(WindowsBuilder.Create10ver1903());
            Add(WindowsBuilder.Create10ver1909());
            Add(WindowsBuilder.Create10ver2004());
            Add(WindowsBuilder.Create10ver20H2());
            Add(WindowsBuilder.Create10ver21H1());
            Add(WindowsBuilder.Create10ver21H2());
            Add(WindowsBuilder.Create10ver22H2());

            //  Windows 11
            Add(WindowsBuilder.Create11ver21H2());
            Add(WindowsBuilder.Create11ver22H2());
            Add(WindowsBuilder.Create11ver23H2());

            //  Windows Server
            Add(WindowsServerBuilder.Create2012());
            Add(WindowsServerBuilder.Create2012R2());
            Add(WindowsServerBuilder.Create2016());
            Add(WindowsServerBuilder.Create2019());
            Add(WindowsServerBuilder.Create2022());
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

        public static OSVersion GetCurrent(OSVersions osVersions = null)
        {
            OSVersion osver = null;
            osVersions ??= OSVersions.Load();

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                //  Windows OS
#pragma warning disable CA1416
                (var osName, var caption, var edition, var version, bool isServer) = WindowsFunctions.GetCurrent();
#pragma warning restore CA1416
                osver = osVersions.
                    Where(x => x.OSFamily == OSFamily.Windows && (x.ServerOS ?? false) == isServer && x.Name == osName).
                    FirstOrDefault(x => x.VersionName == version);
                osver.Edition = Enum.TryParse(edition, out Edition tempEdition) ? tempEdition : Edition.None;
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
    }
}
