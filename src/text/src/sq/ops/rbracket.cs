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
        public static bit rbracket(C src)
            => src == C.RBracket;

        [MethodImpl(Inline), Op]
        public static bit rbracket(char src)
            => src == (char)C.RBracket;
    }
}