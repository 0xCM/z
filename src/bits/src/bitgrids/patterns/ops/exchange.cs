//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class GridPatterns
    {
        /// <summary>
        /// Defines an anti-identity matrix pattern with ones on the anti-diagonal and zeroes elsewhere
        /// </summary>
        /// <param name="w">The grid width selector</param>
        /// <param name="m">The row count selector</param>
        /// <param name="n">The col count selector</param>
        /// <param name="t">The cell type representative</param>
        /// <typeparam name="T">The cell type</typeparam>
        /// <remarks>See https://en.wikipedia.org/wiki/Exchange_matrix</remarks>
        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static BitGrid256<N16,N16,T> exchange<T>(N256 w, N16 m, N16 n, T t = default)
            where T : unmanaged
        {
            var x = gcpu.vmask256<T>(BitMasks.msb<uint>(n2,n1));
            var offsets = gcpu.vinc<T>(w);
            var pattern = gcpu.vsrlv(x,offsets);
            return pattern;
        }
    }
}