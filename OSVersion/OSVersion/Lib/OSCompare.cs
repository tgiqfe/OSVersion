using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSVersion.Lib
{
    internal class OSCompare : OSInfo
    {

        //  ここでoperatorメソッドを


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
        /// != operator。両方OSCompareインスタンス
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator !=(OSCompare x, OSCompare y)
        {
            if(x is not null && y is not null) { return x.Serial != y.Serial; }
            if(x is null && y is null) { return false; }
            return true;
        }





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
