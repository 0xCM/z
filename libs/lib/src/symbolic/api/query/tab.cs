//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

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