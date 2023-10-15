//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    
    partial class BitPack
    {
        /// <summary>
        /// Distributes the first 4 source bits acros 4 segments, each of effective width of 1
        /// </summary>
        /// <param name="src">The packed source bits</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static void unpack1x4(byte src, Span<bit> dst)
            => first(recover<bit,uint>(dst)) = bits.scatter((uint)src, BitMasks.lsb<uint>(n8, n1));        
    }
}