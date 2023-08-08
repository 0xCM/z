//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Raises a vector to a power
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="n">The power</param>
        [Op]
        public static BitVector8 pow(BitVector8 x, int n)
        {
            if(n == 0)
                return BitVector8.Zero;
            else if(n==1)
                return x;
            else
            {
                var dst = x.Replicate();
                for(var i=2; i<=n; i++)
                    dst *= x;
                return dst;
            }
        }
    }
}