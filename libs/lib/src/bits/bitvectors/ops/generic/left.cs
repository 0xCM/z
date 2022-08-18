//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Defines the bitwise LeftProject operator
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal scalar upon which the bitvector is predicated</typeparam>
        [MethodImpl(Inline), LProject, Closures(Closure)]
        public static ScalarBits<T> left<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
                => x;
    }
}