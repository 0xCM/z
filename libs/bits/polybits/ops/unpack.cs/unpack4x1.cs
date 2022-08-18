//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static bits;
    using static BitMasks;

    partial class PolyBits
    {
        /// <summary>
        /// Distributes the first 4 source bits across 4 segments, each of effective width of 1
        /// </summary>
        /// <param name="src">The packed source bits</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static void unpack4x1(num4 src, Span<bit> dst)
            => first(recover<bit,uint>(dst)) = scatter((uint)src, lsb<uint>(n8, n1));
    }
}