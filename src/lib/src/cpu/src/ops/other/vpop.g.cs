//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct gcpu
    {
        /// <summary>
        /// Computes the population count of the content of 3 128-bit vectors
        /// </summary>
        /// <param name="x">The first vector</param>
        /// <param name="y">The second vector</param>
        /// <param name="z">The third vector</param>
        [MethodImpl(Inline), Pop, Closures(Integers)]
        public static uint vpop<T>(Vector128<T> x, Vector128<T> y, Vector128<T> z)
            where T : unmanaged
                => cpu.vpop(v64u(x), v64u(y), v64u(z));

        /// <summary>
        /// Computes the population count of the content of 3 128-bit vectors
        /// </summary>
        /// <param name="x">The first vector</param>
        /// <param name="y">The second vector</param>
        /// <param name="z">The third vector</param>
        [MethodImpl(Inline), Pop, Closures(Integers)]
        public static uint vpop<T>(Vector256<T> x, Vector256<T> y, Vector256<T> z)
            where T : unmanaged
                => cpu.vpop(v64u(x), v64u(y), v64u(z));
    }
}