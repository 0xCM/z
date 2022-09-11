//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Pow2
    {
        /// <summary>
        /// Computes k := 2^n - 1
        /// </summary>
        /// <param name="n">The power of 2 exponent, between 0 and 64</param>
        /// <typeparam name="K">The exponent type</typeparam>
        [MethodImpl(Inline)]
        public static ulong m1<K>(K n = default)
            where K : unmanaged, ITypeNat
        {
            if(typeof(K) == typeof(N64))
                return ulong.MaxValue;
            else
                return pow2(n) - 1ul;
        }
    }
}