using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSVersion.Lib.OSVersion.Any
{
    internal class AnyOS : OSInfo
    {
        #region Serial calcurate

        private int _serial = -1;

        protected override int Serial
        {
            get
            {
                if (_serial < 0) _serial = GetSerial();
                return _serial;
            }
        }

        private int GetSerial()
        {
            return Name switch
            {
                "MinimumOS" => int.MinValue,
                "MaximumOS" => int.MaxValue,
                _ => 0,
            };
        }

        #endregion

        public AnyOS()
        {
            OSFamily = OSFamily.Any;
        }

        /// <summary>
        /// 必ず最小と判定する為のOS
        /// </summary>
        /// <returns></returns>
        public static AnyOS CreateMinimum()
        {
            return new AnyOS()
            {
                Name = "MinimumOS",
                VersionName = int.MinValue.ToString(),
            };
        }

        /// <summary>
        /// 必ず最大と判定する為のOS
        /// </summary>
        /// <returns></returns>
        public static AnyOS CreateMaximum()
        {
            return new AnyOS()
            {
                Name = "MaximumOS",
                VersionName = int.MaxValue.ToString(),
            };
        }
    }
}
