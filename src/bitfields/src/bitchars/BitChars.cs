//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using K = BitCharKind;
    using D = BitChars.CharData;

    [ApiHost]
    public readonly struct BitChars
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<BitChar> edit<T>(ref BitChars<T> src)
            where T : unmanaged
                => recover<BitChar>(bytes(src));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<BitChar> view<T>(in BitChars<T> src)
            where T : unmanaged
                => recover<BitChar>(bytes(src));

        public static BitChar SectionSep
        {
            [MethodImpl(Inline), Op]
            get => BitCharKind.SectionSep;
        }

        public static BitChar SegSep
        {
            [MethodImpl(Inline), Op]
            get => BitCharKind.SegSep;
        }

        public static BitChar LeftFence
        {
            [MethodImpl(Inline), Op]
            get => BitCharKind.LeftFence;
        }

        public static BitChar RightFence
        {
            [MethodImpl(Inline), Op]
            get => BitCharKind.RightFence;
        }

        [MethodImpl(Inline), Op]
        public static BitChar from(bit src)
            => new BitChar(src ? BitCharKind.On : BitCharKind.Off);

        [MethodImpl(Inline), Op]
        public static char render(BitChar src)
            => (char)src.Kind;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitChars<T> block<T>(T data)
            where T : unmanaged
                => new BitChars<T>(data);

        [MethodImpl(Inline), Op]
        public static ref readonly BitCharKind kind(BitCharIndex index)
            => ref skip(CharData.Kinds, (byte)index);

        [MethodImpl(Inline), Op]
        public static uint render<T>(in BitChars<T> src, Span<char> dst)
            where T : unmanaged
        {
            var count = src.Count;
            var bits = view(src);
            for(var i=0; i<count; i++)
                seek(dst,i) = skip(bits,i);
            return count;
        }

        [MethodImpl(Inline), Op]
        public static uint render(ReadOnlySpan<BitChar> src, Span<char> dst)
        {
            var count = (uint)min(src.Length, dst.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = skip(src,i);
            return count;
        }

        [MethodImpl(Inline), Op]
        public static string format(ReadOnlySpan<BitChar> src)
        {
            var count = src.Length;
            Span<char> dst = stackalloc char[count];
            render(src,dst);
            return new string(dst);
        }

        [MethodImpl(Inline), Op]
        public static string text(N0 n)
            =>  D.Off;

        [MethodImpl(Inline), Op]
        public static string text(N1 n)
            =>  D.On;

        [MethodImpl(Inline), Op]
        public static string text(N2 n)
            =>  D.SectionSep;

        [MethodImpl(Inline), Op]
        public static string text(N3 n)
            =>  D.SegSep;

        [MethodImpl(Inline), Op]
        public static string text(N4 n)
            =>  D.LeftFence;

        [MethodImpl(Inline), Op]
        public static string text(N5 n)
            =>  D.RightFence;

        [MethodImpl(Inline), Op]
        public static string text(N6 n)
            =>  D.Space;

        [MethodImpl(Inline), Op]
        public static string format(BitChar src)
            => src.Kind switch {
                K.Off => text(n0),
                K.On => text(n1),
                K.SectionSep => text(n2),
                K.SegSep => text(n3),
                K.LeftFence => text(n4),
                K.RightFence=> text(n5),
                _ => CharText.Space
            };

        internal readonly struct CharData
        {
            public const string Off = "0";

            public const string On = "0";

            public const string SectionSep = "|";

            public const string SegSep = " ";

            public const string LeftFence = "[";

            public const string RightFence = "]";

            public const string Space = " ";

            public const string CharText = Off + On + SectionSep + SegSep + LeftFence + RightFence + Space;

            public ReadOnlySpan<char> Chars
            {
                [MethodImpl(Inline)]
                get => CharText;
            }

            public static ReadOnlySpan<BitCharKind> Kinds
                => new BitCharKind[7]{K.On, K.Off, K.SectionSep, K.SegSep, K.LeftFence, K.RightFence, K.Space};
        }        
    }

    public static partial class XTend
    {
        public static BitChar ToBitChar(this bit src)
            => BitChars.from(src);

        public static string Format(this ReadOnlySpan<BitChar> src)
            => BitChars.format(src);

        public static string Format(this Span<BitChar> src)
            => BitChars.format(src);
    }
}