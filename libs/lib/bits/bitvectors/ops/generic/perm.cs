//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Rearranges the vector as specified by a permutation
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="spec">The permutation</param>
        [Op, Closures(Closure)]
        public static ScalarBits<T> perm<T>(ScalarBits<T> src, in Perm spec)
            where T : unmanaged
        {
            var dst = replicate(src);
            var w = src.Width;
            for(var i=0; i<w; i++)
            {
                ref readonly var j = ref spec[i];
                if(j != i)
                    dst[i] = src[j];
            }
            return dst;
        }

        public static ScalarBits<N,T> perm<N,T>(ScalarBits<N,T> src, in Perm spec)
            where T : unmanaged
            where N : unmanaged, ITypeNat
        {
            var dst = src.Replicate();
            var n = src.Width;
            for(var i=0; i<n; i++)
                dst[i] = src[spec[i]];
            return dst;
        }
    }
}