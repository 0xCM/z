//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
 
    partial class math
    {
        [MethodImpl(Inline), Op]
        public static ulong pow2(int exp)
            => 1ul << exp;

        [MethodImpl(Inline), Op]
        public static ulong pow2m1(int exp)
            => pow2(exp) - 1;
    }
}