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
        public static ReadOnlySpan<char> inflate16u(in ByteBlock4 src, ref ulong dst)
        {
            //var storage = 0ul;
            var input = u32(src);
            ref var chars = ref @as<ulong,char>(dst);
            seek(chars, 0) = (char)(byte)(input >> 0);
            seek(chars, 1) = (char)(byte)(input >> 8);
            seek(chars, 2) = (char)(byte)(input >> 16);
            seek(chars, 3) = (char)(byte)(input >> 24);
            return cover(chars, 4);
        }
    }
}