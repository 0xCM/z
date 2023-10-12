//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitSpans
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void store<T>(T src, BitSpan dst)
            where T : unmanaged
               => BitPack.unpack(src, dst.Storage);
    }
}