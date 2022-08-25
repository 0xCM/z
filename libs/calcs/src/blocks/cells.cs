//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class BitBlocks
    {
        /// <summary>
        /// Computes the number of primal cells required to cover a specified number of bits
        /// </summary>
        /// <param name="bitcount">The number of bits to cover</param>
        /// <typeparam name="T">The primal cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static int cells<T>(int bitcount)
            where T : unmanaged
        {
            var q = Math.DivRem(bitcount, (int)width<T>(), out int r);
            return r == 0 ? q : q + 1;
        }
    }
}