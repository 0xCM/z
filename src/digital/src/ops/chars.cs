//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines operations over character digits
    /// </summary>
    partial struct Digital
    {
        [MethodImpl(Inline), Op]
        public static void chars(Base10 @base, ushort src, out char c1, out char c0)
        {
            c1 = (char)symbol(digit(@base, src, 1));
            c0 = (char)symbol(digit(@base, src, 0));
        }

        [MethodImpl(Inline), Op]
        public static void chars(Base10 @base, uint src, out char c3, out char c2, out char c1, out char c0)
        {
            c3 = (char)symbol(digit(@base, src, 3));
            c2 = (char)symbol(digit(@base, src, 2));
            c1 = (char)symbol(digit(@base, src, 1));
            c0 = (char)symbol(digit(@base, src, 0));
        }

        [MethodImpl(Inline), Op]
        public static void chars(Base10 @base, ulong src, out char c7, out char c6, out char c5, out char c4, out char c3, out char c2, out char c1, out char c0)
        {
            c7 = (char)symbol(digit(@base, src, 7));
            c6 = (char)symbol(digit(@base, src, 6));
            c5 = (char)symbol(digit(@base, src, 5));
            c4 = (char)symbol(digit(@base, src, 4));
            c3 = (char)symbol(digit(@base, src, 3));
            c2 = (char)symbol(digit(@base, src, 2));
            c1 = (char)symbol(digit(@base, src, 1));
            c0 = (char)symbol(digit(@base, src, 0));
        }

        [MethodImpl(Inline), Op]
        public static void chars(ushort src, out char c1, out char c0)
            => chars(base10, src, out c1, out c0);

        [MethodImpl(Inline), Op]
        public static void chars(uint src, out char c3, out char c2, out char c1, out char c0)
            => chars(base10, src, out c3, out c2, out c1, out c0);

        [MethodImpl(Inline), Op]
        public static void chars(ulong src, out char c7, out char c6, out char c5, out char c4, out char c3, out char c2, out char c1, out char c0)
            => chars(base10, src, out c7, out c6, out c5, out c4, out c3, out c2, out c1, out c0);

        [MethodImpl(Inline), Op]
        public static void chars(ReadOnlySpan<BinaryDigitValue> src, Span<char> dst)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                seek(dst,i) = ((bit)skip(src,i)).ToChar();
        }
   }
}