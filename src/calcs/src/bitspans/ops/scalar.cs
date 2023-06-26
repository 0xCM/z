//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class BitSpans
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void scalar<T>(T src, BitSpan dst)
            where T : unmanaged
        {
            if(size<T>() == 1)
                BitPack.unpack1x8(bw8(src), dst.Storage);
            else if(size<T>() == 2)
                BitPack.unpack1x16x8(bw16(src), dst.Storage);
            else if(size<T>() == 4)
                BitPack.unpack1x32x8(bw32(src), dst.Storage);
            else if(size<T>() == 8)
                BitPack.unpack1x64(bw64(src), dst.Storage);
            else
                sys.@throw(no<T>());
        }
    }
}