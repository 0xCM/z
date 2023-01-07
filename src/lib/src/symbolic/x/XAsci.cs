//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        [MethodImpl(Inline)]
        public static int FirstIndexOf<T>(this T src, AsciCharSym match)
            where T : unmanaged,IAsciSeq
                => AsciG.index(src, match);

        [MethodImpl(Inline)]
        public static bool Contains<T>(this T src, AsciCharSym match)
            where T : unmanaged,IAsciSeq
                => AsciG.contains(src, match);

        public static string Format(this ReadOnlySpan<AsciCode> src)
            => Asci.format(src);

        public static string Format(this Span<AsciCode> src)
            => Asci.format(src);

        public static string Format(this ReadOnlySpan<AsciSymbol> src)
            => Asci.format(src);

        public static string Format(this Span<AsciSymbol> src)
            => Asci.format(src);

    }
}
