//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Arrays;
    using static Spans;
    using static Algs;

    partial struct Hex
    {
        [MethodImpl(Inline), Op]
        public static HexArray hexarray(byte[] src)
            => new HexArray(src);

        [MethodImpl(Inline), Op]
        public static HexArray16 array(ReadOnlySpan<byte> src, N16 n)
        {
            var size = src.Length;
            if(size <= 16)
                return @as<HexArray16>(first(src));
            else
            {
                var dst = HexArray16.Empty;
                Hex.store(src,ref dst);
                return dst;
            }
        }
    }
}