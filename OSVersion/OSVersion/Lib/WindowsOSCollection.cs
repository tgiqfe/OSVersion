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
    internal class WindowsOSCollection : List<WindowsOS>
    {
        const string dbFileName = "windowsOSCollection.json";

        public void LoadDefault()
        {
            //
            //
            //  ここにデフォルト値を読み込む処理を記述
            //
            //
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
                    result = JsonSerializer.Deserialize<WindowsOSCollection>(sr.ReadToEnd());
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
                    WriteIndented = true,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
                });
                sw.WriteLine(json);
            }
        }

        #endregion
    }
}
