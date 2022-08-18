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
        /// <summary>
        /// Computes k := k1*k1
        /// </summary>
        [MethodImpl(Inline)]
        public static ulong square<K1>(K1 k1 = default)
            where K1 : unmanaged, ITypeNat
                => mul(k1,k1);
    }
}