//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using F = AsciCodeFacets;

    using static sys;
    using static AsciChars;

    [ApiHost]
    public readonly struct AsciTables
    {
        [MethodImpl(Inline), Op]
        static AsciTable table(AsciTableKind kind, AsciCode min, AsciCode max)
            => new AsciTable(kind, min, max);

        [MethodImpl(Inline), Op]
        public static AsciTable segment(AsciCode min, AsciCode max)
            => new AsciTable(AsciTableKind.None, min,max);

        [MethodImpl(Inline), Op]
        public static AsciTable digits()
            => table(AsciTableKind.Digits, F.MinDigitCode, F.MaxDigitCode);

        [MethodImpl(Inline), Op]
        public static AsciTable letters(LowerCased @case)
            => table(AsciTableKind.LowerLetters, F.MinLowerLetter, F.MaxLowerLetter);

        [MethodImpl(Inline), Op]
        public static AsciTable letters(UpperCased @case)
            => table(AsciTableKind.UpperLetters, F.MinUpperLetter, F.MaxUpperLetter);

        [MethodImpl(Inline), Op]
        public static AsciTable table()
            => new AsciTable(AsciTableKind.Full, F.MinCode, F.MaxCode);

        /// <summary>
        /// Returns the asci characters corresponding to the asci codes [offset, ..., offset + count] where offset <= (2^7-1) - count
        /// </summary>
        /// <param name="offset">The zero-based offset</param>
        /// <param name="count">Tne number of characters to select</param>
        [MethodImpl(Inline), Op]
        internal static ReadOnlySpan<char> chars(sbyte offset, sbyte count)
            => slice(recover<char>(CharBytes), offset, count);

        /// <summary>
        /// Returns the asci codes [offset, ..., offset + count] where offset <= (2^7-1) - count
        /// </summary>
        /// <param name="offset">The zero-based offset</param>
        /// <param name="count">Tne number of codes to select</param>
        [MethodImpl(Inline), Op]
        internal static ReadOnlySpan<AsciCode> codes(sbyte offset, sbyte count)
            => recover<AsciCode>(slice(AsciChars.CodeBytes, offset, count));

        [MethodImpl(Inline), Op]
        internal static ReadOnlySpan<AsciSymbol> symbols(sbyte offset, sbyte count)
            => recover<AsciSymbol>(slice(AsciChars.CodeBytes, offset, count));
    }
}