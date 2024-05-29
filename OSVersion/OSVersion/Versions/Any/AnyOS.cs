namespace OSVersion.Versions.Any
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
        /// Force minimum OS
        /// </summary>
        /// <returns></returns>
        public static AnyOS CreateMinimum()
        {
            return new AnyOS()
            {
                Name = "MinimumOS",
                Alias = new string[0] { },
                VersionName = int.MinValue.ToString(),
                VersionAlias = new string[0] { },
            };
        }

        /// <summary>
        /// Force maximum OS
        /// </summary>
        /// <returns></returns>
        public static AnyOS CreateMaximum()
        {
            return new AnyOS()
            {
                Name = "MaximumOS",
                Alias = new string[0] { },
                VersionName = int.MaxValue.ToString(),
                VersionAlias = new string[0] { },
            };
        }
    }
}
