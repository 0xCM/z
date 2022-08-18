//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using F = AsciCodeFacets;

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
    }
}