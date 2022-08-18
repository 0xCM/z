//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Computes the smallest integer n > 1 such that v^n = identity
        /// </summary>
        public static int ord(BitVector8 x)
        {
            var dst = x.Replicate();
            for(var i=2; i<Gf256.MemberCount; i++)
            {
                dst *= x;
                if(dst == BitVector8.One)
                    return i;
            }
            return 0;
        }
    }
}