//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = TextEncodingKind;

    using System.Text;

    using static Algs;
    using static Spans;

    public readonly struct TextEncodings
    {
        public static AsciPoints Asci => default;

        public static Utf8Points Utf8 => default;

        public static UnicodePoints Unicode => default;
    }

    public readonly struct AsciPoints : ITextEncodingKind<AsciPoints>
    {
        public static AsciPoints Value => default;

        [MethodImpl(Inline), Op]
        public static string text(ReadOnlySpan<byte> src)
            => Encoding.ASCII.GetString(src);

        [MethodImpl(Inline), Op]
        public static unsafe string text(byte* pSrc, ByteSize size)
            => Encoding.ASCII.GetString(pSrc,size);

        [MethodImpl(Inline), Op]
        public static uint compact(ReadOnlySpan<char> src, Span<byte> dst)
        {
            var chars = src;
            var count = (uint)min(chars.Length, dst.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = (byte)skip(chars, i);
            return count;
        }

        [MethodImpl(Inline), Op]
        public static uint decode(ReadOnlySpan<byte> src, Span<char> dst)
            => (uint)Encoding.ASCII.GetChars(src,dst);

        public K Kind => K.Asci;
    }

    public readonly struct Utf8Points : ITextEncodingKind<Utf8Points>
    {
        public static Utf8Points Value => default;

        public K Kind => K.Utf8;
    }

    public readonly struct UnicodePoints : ITextEncodingKind<UnicodePoints>
    {
        public static UnicodePoints Value => default;

        public K Kind => K.Unicode;
    }

    public readonly struct Utf32Points : ITextEncodingKind<Utf32Points>
    {
        public K Kind => K.Utf32;
    }
}