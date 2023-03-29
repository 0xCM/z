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
                => AsciSymbols.index(src, match);

        [MethodImpl(Inline)]
        public static bool Contains<T>(this T src, AsciCharSym match)
            where T : unmanaged,IAsciSeq
                => AsciSymbols.contains(src, match);

        public static string Format(this ReadOnlySpan<AsciCode> src)
            => AsciSymbols.format(src);

        public static string Format(this Span<AsciCode> src)
            => AsciSymbols.format(src);

        public static string Format(this ReadOnlySpan<AsciSymbol> src)
            => AsciSymbols.format(src);

        public static string Format(this Span<AsciSymbol> src)
            => AsciSymbols.format(src);

    }
}