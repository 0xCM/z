//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static TypeNats;

    partial class NatCalc
    {
        /// <summary>
        /// Computes k := x >> n
        /// </summary>
        [MethodImpl(Inline)]
        public static ulong srl<X,N>(X x = default, N n = default)
            where X : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
                => value(x) >> (int)value(n);
    }
}