using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSVersion.Lib
{
    internal class OSCompare : OSInfo
    {
        #region <

        /// <summary>
        /// < operator。両方OSCompareインスタンス
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator <(OSCompare x, OSCompare y)
        {
            return x is not null && y is not null ? x.Serial < y.Serial : false;
        }

        #endregion
        #region >

        /// <summary>
        /// >
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator >(OSCompare x, OSCompare y)
        {
            return x is not null && y is not null ? x.Serial > y.Serial : false;
        }

        #endregion
        #region <=

        /// <summary>
        /// <= operator。両方OSCompareインスタンス
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator <=(OSCompare x, OSCompare y)
        {
            return x is not null && y is not null ? x.Serial <= y.Serial : false;
        }

        #endregion
        #region >=

        /// <summary>
        /// >= operator。両方OSCompareインスタンス
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator >=(OSCompare x, OSCompare y)
        {
            return x is not null && y is not null ? x.Serial >= y.Serial : false;
        }

        #endregion

        #region ==

        /// <summary>
        /// == operator。両方OSCompareインスタンス
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator ==(OSCompare x, OSCompare y)
        {
            if (x is not null && y is not null) { return x.Serial == y.Serial; }
            if (x is null && y is null) { return true; }
            return false;
        }

        /// <summary>
        /// == operator。左辺がCompareインスタンス
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator ==(OSCompare x, int y) { return x is not null ? x.Serial == y : false; }

        /// <summary>
        /// == operator。右辺がCompareインスタンス
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator ==(int x, OSCompare y) { return y is not null ? x == y.Serial : false; }

        #endregion
        #region !=

        /// <summary>
        /// != operator。両方OSCompareインスタンス
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator !=(OSCompare x, OSCompare y)
        {
            if (x is not null && y is not null) { return x.Serial != y.Serial; }
            if (x is null && y is null) { return false; }
            return true;
        }

        /// <summary>
        /// != operator。左辺がCompareインスタンス
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator !=(OSCompare x, int y) { return x is not null ? x.Serial != y : true; }

        /// <summary>
        /// != operator。右辺がCompareインスタンス
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator !=(int x, OSCompare y) { return y is not null ? x != y.Serial : true; }

        #endregion

        public override bool Equals(object obj)
        {
            return obj switch
            {
                OSCompare o => this.Serial == o.Serial,
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
