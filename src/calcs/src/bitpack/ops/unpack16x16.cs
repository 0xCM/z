//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct BitPack
    {
        /// <summary>
        /// Projects 16 8-bit segments onto 16 16-bit targets
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="src">The target</param>
        [MethodImpl(Inline), Op]
        public static void unpack16x16(in Cell128 src, Span<ushort> dst)
            => vgcpu.vstore(vpack.vinflate256x16u(src), dst);
    }
}