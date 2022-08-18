//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct CellCalcs
    {
        /// <summary>
        /// Computes the number of blocks required to cover a specified number of bits
        /// </summary>
        /// <param name="bitcount">The source bit count</param>
        /// <param name="blockwidth">The block width in bits</param>
        [MethodImpl(Inline), Op]
        public static uint bitcover(uint bitcount, uint blockwidth)
        {
            if(blockwidth == 0)
                return 0;

            var a = bitcount / blockwidth;
            return a + (bitcount % a == 0 ? 0u : 1u);
        }

        /// <summary>
        /// Computes the number of blocks required to cover a specified number of bits
        /// </summary>
        /// <param name="dstblockbits">The target block size in bits</param>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static uint bitcover<T>(uint bitcount)
            where T : unmanaged
                => bitcover(bitcount, (uint)core.width<T>());
    }
}