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
        public static bit rparen(C c)
            => C.RParen == c;

        [MethodImpl(Inline), Op]
        public static bit rparen(char c)
            => (char)C.RParen == c;
    }
}