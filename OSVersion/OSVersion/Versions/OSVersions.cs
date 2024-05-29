using OSVersion.Versions.Builder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OSVersion.Versions
{
    internal class OSVersions : List<OSVersion>
    {
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
        public static OSVersions Load(string path)
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
        public void Save(string path)
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
    }
}
