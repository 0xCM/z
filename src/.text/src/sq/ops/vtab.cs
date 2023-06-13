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
        public static bit vtab(C src)
            => src == C.VTab;

        [MethodImpl(Inline), Op]
        public static bit vtab(char src)
            => src == (char)C.VTab;
    }
}