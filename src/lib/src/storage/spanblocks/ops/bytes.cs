//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct SpanBlocks
    {
        [MethodImpl(Inline), Op]
        public static SpanBlock8<byte> bytes(W8 w, Span<byte> src)
            => new SpanBlock8<byte>(src);

        [MethodImpl(Inline), Op]
        public static SpanBlock16<byte> bytes(W16 w, Span<byte> src)
        {
            const byte Size = 2;
            var div = src.Length / Size;
            if(div > 0)
                return new SpanBlock16<byte>(cover(first(src), Size * div));
            else
                return default;
        }

        [MethodImpl(Inline), Op]
        public static SpanBlock32<byte> bytes(W32 w, Span<byte> src)
        {
            const byte Size = 4;
            var div = src.Length / Size;
            if(div > 0)
                return new SpanBlock32<byte>(cover(first(src), Size * div));
            else
                return default;
        }

        [MethodImpl(Inline), Op]
        public static SpanBlock64<byte> bytes(W64 w, Span<byte> src)
        {
            const byte Size = 8;
            var div = src.Length / Size;
            if(div > 0)
                return new SpanBlock64<byte>(cover(first(src), Size * div));
            else
                return default;
        }

        [MethodImpl(Inline), Op]
        public static SpanBlock128<byte> bytes(W128 w, Span<byte> src)
        {
            const byte Size = 16;
            var div = src.Length / Size;
            if(div > 0)
                return new SpanBlock128<byte>(cover(first(src), Size * div));
            else
                return default;
        }

        [MethodImpl(Inline), Op]
        public static SpanBlock256<byte> bytes(W256 w, Span<byte> src)
        {
            const byte Size = 32;
            var div = src.Length / Size;
            if(div > 0)
                return new SpanBlock256<byte>(cover(first(src), Size * div));
            else
                return default;
        }
    }
}