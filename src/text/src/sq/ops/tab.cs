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
        public static bit tab(C src)
            => src == C.Tab;

        [MethodImpl(Inline), Op]
        public static bit tab(char src)
            => src == (char)C.Tab;
    }
}