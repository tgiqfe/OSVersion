using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Text.Json.Serialization;
using OSVersion.Lib.OSVersion.Windows;
using OSVersion.Lib.OSVersion.Any;

namespace OSVersion.Lib.OSVersion
{
    internal class OSCollection : List<OSInfo>
    {
        public void LoadDefault()
        {
            //  Windowos 10
            Add(Windows10.Create1507());
            Add(Windows10.Create1607());
            Add(Windows10.Create1703());
            Add(Windows10.Create1709());
            Add(Windows10.Create1803());
            Add(Windows10.Create1809());
            Add(Windows10.Create1903());
            Add(Windows10.Create1909());
            Add(Windows10.Create2004());
            Add(Windows10.Create20H2());
            Add(Windows10.Create21H1());
            Add(Windows10.Create21H2());

            //  Windows 11
            Add(Windows11.Create21H2());

            //  Windows Server
            Add(WindowsServer.Create2012());
            Add(WindowsServer.Create2012R2());
            Add(WindowsServer.Create2016());
            Add(WindowsServer.Create2019());
            Add(WindowsServer.Create2022());

            //  AnyOS
            Add(AnyOS.CreateMinimum());
            Add(AnyOS.CreateMaximum());
        }

        public List<OSInfo> GetMatchOS(string keyword)
        {
            var list = new List<OSInfo>();
            list.AddRange(this.Where(x => x.VersionName == keyword));
            list.AddRange(this.Where(x => x.VersionAlias.Any(y => y.Equals(keyword, StringComparison.OrdinalIgnoreCase))));
            list.AddRange(
                this.Where(x => keyword.StartsWith(x.Name, StringComparison.OrdinalIgnoreCase) ||
                    x.Alias.Any(y => keyword.StartsWith(y, StringComparison.OrdinalIgnoreCase))).
                    Where(x => keyword.EndsWith(x.VersionName, StringComparison.OrdinalIgnoreCase) ||
                    x.VersionAlias.Any(y => keyword.EndsWith(y, StringComparison.OrdinalIgnoreCase))));

            return list;
        }

        #region Load/Save

        /// <summary>

        public static OSCollection Load(string filePath)
        {
            OSCollection collection = null;
            try
            {
                using (var sr = new StreamReader(filePath, Encoding.UTF8))
                {
                    collection = JsonSerializer.Deserialize<OSCollection>(sr.ReadToEnd(), new JsonSerializerOptions()
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
                collection = new OSCollection();
                collection.LoadDefault();
                collection.Save(filePath);
            }
            return collection;
        }

        public void Save(string filePath)
        {
            string parent = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(parent))
            {
                Directory.CreateDirectory(parent);
            }
            using (var sw = new StreamWriter(filePath, false, Encoding.UTF8))
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

        #endregion
    }
}
