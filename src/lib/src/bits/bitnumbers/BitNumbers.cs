//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public readonly partial struct BitNumbers
    {
        static string format<T>(W8 w, T src)
            where T : unmanaged, IBitNumber
        {
            var width = src.Width;
            var i=0u;
            Span<char> buffer = stackalloc char[8];
            BitRender.render8(bw8(src), ref i, buffer);
            var chars = slice(buffer, buffer.Length - width);
            return new string(chars);
        }

        public static string format<T>(T src)
            where T : unmanaged, IBitNumber
        {
            var width = src.Width;
            var dst = EmptyString;
            var i=0u;
            if(width <= 8)
                dst = format(w8,src);
            else if(width <= 16)
            {
                Span<char> buffer = stackalloc char[16];
                BitRender.render16(bw16(src), ref i, buffer);
                var chars = slice(buffer, buffer.Length - width);
                dst = new string(chars);
            }
            else if(width <= 32)
            {
                Span<char> buffer = stackalloc char[32];
                BitRender.render32(bw32(src), ref i, buffer);
                var chars = slice(buffer, buffer.Length - width);
                dst = new string(chars);
            }
            else
            {
                Span<char> buffer = stackalloc char[64];
                BitRender.render64(bw64(src), ref i, buffer);
                var chars = slice(buffer, buffer.Length - width);
                dst = new string(chars);
            }

            return dst;
        }

        public const NumericKind Closure = NumericKind.UnsignedInts;

        [MethodImpl(Inline)]
        internal static void render(uint src, byte count, uint offset, Span<char> dst)
        {
            byte i=0;
            for(var j=offset; j<count; j++)
                seek(dst, j) = @char(@bool(bit.test(src, i++)));
        }
    }
}