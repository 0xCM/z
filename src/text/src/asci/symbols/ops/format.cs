//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct AsciSymbols
    {
        [Op]
        public static string format(ReadOnlySpan<AsciCode> src)
        {
            Span<char> dst = stackalloc char[src.Length];
            decode(src, dst);
            return new string(dst);
        }

        [Op]
        public static string format(ReadOnlySpan<AsciSymbol> src)
        {
            Span<char> dst = stackalloc char[src.Length];
            decode(src, dst);
            return new string(dst);
        }
    }
}