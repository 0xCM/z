//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using C = AsciCode;

    partial struct SymbolicQuery
    {
        [MethodImpl(Inline), Op]
        public static bit lparen(C c)
            => c == C.LParen;

        [MethodImpl(Inline), Op]
        public static bit lparen(char c)
            => c == (char)C.LParen;
    }
}