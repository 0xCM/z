//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static bits;

    partial class PolyBits
    {
        /// <summary>
        /// Partitions the source into 16 segments, each of effective width 1
        /// </summary>
        /// <param name="src">The packed source bits</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static void unpack16x1(num16 src, Span<bit> dst)
        {
            var mask = BitMasks.lsb<ulong>(n8, n1);
            ref var lead = ref first(dst);
            seek64(lead, 0) = scatter((ulong)(byte)src, mask);
            seek64(lead, 1) = scatter((ulong)((byte)(src >> 8)), mask);
        }
    }
}