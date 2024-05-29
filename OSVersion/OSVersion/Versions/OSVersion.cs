namespace OSVersion.Versions
{
    /// <summary>
    /// Version 4.0
    /// </summary>
    internal class OSVersion : OSComparer
    {
        #region Public parameter

        /// <summary>
        /// OS type. [Windows/Linux/Mac/Any]
        /// </summary>
        public OSFamily OSFamily { get; set; }

        /// <summary>
        /// OS name.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// OS name alias.
        /// </summary>
        public string[] Alias { get; set; }

        /// <summary>
        /// Version name.
        /// </summary>
        public string VersionName { get; set; }

        /// <summary>
        /// Version name alias.
        /// </summary>
        public string[] VersionAlias { get; set; }

        /// <summary>
        /// OS edition.
        /// </summary>
        public Edition? Edition { get; set; }

        /// <summary>
        /// server / not server
        /// </summary>
        public bool? ServerOS { get; set; }

        /// <summary>
        /// embedded os / not embedded os
        /// </summary>
        public bool? EmbeddedOS { get; set; }

        /// <summary>
        /// for simple version compare.
        /// </summary>
        public override int Serial { get; set; }

        #endregion

        public bool IsMatch(string keyword)
        {
            if (this.VersionName == keyword) return true;
            if (this.VersionAlias?.Any(x => x.Equals(keyword, StringComparison.OrdinalIgnoreCase)) ?? false) return true;
            if ((keyword.StartsWith(this.Name) || (this.Alias?.Any(x => keyword.StartsWith(x)) ?? false)) &&
                (keyword.EndsWith(this.VersionName) || (this.VersionAlias?.Any(x => keyword.EndsWith(x)) ?? false))) return true;
            return false;
        }

        public override string ToString()
        {
            return $"{Name} [ver {VersionName}]";
        }
    }
}
