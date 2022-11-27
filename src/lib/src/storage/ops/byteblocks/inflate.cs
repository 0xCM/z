//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class ByteBlocks
    {
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> inflate16u(in ByteBlock4 src)
        {
            var storage = 0ul;
            var input = u32(src);
            ref var dst = ref @as<ulong,char>(storage);
            seek(dst, 0) = (char)(byte)(input >> 0);
            seek(dst, 1) = (char)(byte)(input >> 8);
            seek(dst, 2) = (char)(byte)(input >> 16);
            seek(dst, 3) = (char)(byte)(input >> 24);
            return cover(dst, 4);
        }
    }
}