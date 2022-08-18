//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class NatCalc
    {
        [MethodImpl(Inline)]
        public static bool between<K,K1,K2>(K k = default, K1 k1 = default, K2 k2 = default)
            where K : unmanaged, ITypeNat
            where K1 : unmanaged, ITypeNat
            where K2 : unmanaged, ITypeNat
                => gteq(k,k1) && lteq(k,k2);
    }
}