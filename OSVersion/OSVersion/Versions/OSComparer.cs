namespace OSVersion.Versions
{
    internal class OSComparer
    {
        #region <

        /// <summary>
        /// 小なりoperator。両方OSCompareインスタンス
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator <(OSComparer x, OSComparer y)
        {
            return x is not null && y is not null ? (x.Name == y.Name && x.Serial < y.Serial) : false;
        }

        /// <summary>
        /// 小なりoperator。左辺のみOSCompareインスタンス
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator <(OSComparer x, int y) { return x is not null ? x.Serial < y : false; }

        /// <summary>
        /// 小なりoperator。右辺のみOSCompareインスタンス
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator <(int x, OSComparer y) { return y is not null ? x < y.Serial : false; }

        #endregion
        #region >

        /// <summary>
        /// 大なりoperator。両方OSCompareインスタンス
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator >(OSComparer x, OSComparer y)
        {
            return x is not null && y is not null ? (x.Name == y.Name && x.Serial > y.Serial) : false;
        }

        /// <summary>
        /// 大なりoperator。左辺のみOSCompareインスタンス
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator >(OSComparer x, int y) { return x is not null ? x.Serial > y : false; }

        /// <summary>
        /// 大なりoperator。右辺のみOSCompareインスタンス
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator >(int x, OSComparer y) { return y is not null ? x > y.Serial : false; }


        #endregion
        #region <=

        /// <summary>
        /// 小なりイコールoperator。両方OSCompareインスタンス
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator <=(OSComparer x, OSComparer y)
        {
            return x is not null && y is not null ? (x.Name == y.Name && x.Serial <= y.Serial) : false;
        }

        /// <summary>
        /// 小なりイコールoperator。左辺のみOSCompareインスタンス
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator <=(OSComparer x, int y) { return x is not null ? x.Serial <= y : false; }

        /// <summary>
        /// 小なりイコールoperator。右辺のみOSCompareインスタンス
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator <=(int x, OSComparer y) { return y is not null ? x <= y.Serial : false; }

        #endregion
        #region >=

        /// <summary>
        /// 大なりイコールoperator。両方OSCompareインスタンス
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator >=(OSComparer x, OSComparer y)
        {
            return x is not null && y is not null ? (x.Name == y.Name && x.Serial >= y.Serial) : false;
        }

        /// <summary>
        /// 大なりイコールoperator。左辺のみOSCompareインスタンス
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator >=(OSComparer x, int y) { return x is not null ? x.Serial >= y : false; }

        /// <summary>
        /// 大なりイコールoperator。右辺のみOSCompareインスタンス
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator >=(int x, OSComparer y) { return y is not null ? x >= y.Serial : false; }

        #endregion
        #region ==

        /// <summary>
        /// == operator。両方OSCompareインスタンス
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator ==(OSComparer x, OSComparer y)
        {
            if (x is not null && y is not null) { return x.Name == y.Name && x.Serial == y.Serial; }
            if (x is null && y is null) { return true; }
            return false;
        }

        /// <summary>
        /// == operator。左辺がCompareインスタンス
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator ==(OSComparer x, int y) { return x is not null ? x.Serial == y : false; }

        /// <summary>
        /// == operator。右辺がCompareインスタンス
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator ==(int x, OSComparer y) { return y is not null ? x == y.Serial : false; }

        #endregion
        #region !=

        /// <summary>
        /// != operator。両方OSCompareインスタンス
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator !=(OSComparer x, OSComparer y)
        {
            if (x is not null && y is not null) { return x.Name != y.Name || x.Serial != y.Serial; }
            if (x is null && y is null) { return false; }
            return true;
        }

        /// <summary>
        /// != operator。左辺がCompareインスタンス
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator !=(OSComparer x, int y) { return x is not null ? x.Serial != y : true; }

        /// <summary>
        /// != operator。右辺がCompareインスタンス
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator !=(int x, OSComparer y) { return y is not null ? x != y.Serial : true; }

        #endregion


        /// <summary>
        /// OSの名前
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 単純なバージョン比較用
        /// </summary>
        protected virtual int Serial { get; }

        public override bool Equals(object obj)
        {
            return obj switch
            {
                OSComparer o => this.Serial == o.Serial,
                int i => this.Serial == i,
                long l => this.Serial == l,
                _ => false,
            };
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
