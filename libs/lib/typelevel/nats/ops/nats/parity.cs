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
        /// Computes k := k % 2 == 0
        /// </summary>
        [MethodImpl(Inline)]
        public static bool even<K1>(K1 k1 = default)
            where K1 : unmanaged, ITypeNat
                => mod<K1,N2>() == 0;

        /// <summary>
        /// Computes k := k % 2 != 0
        /// </summary>
        [MethodImpl(Inline)]
        public static bool odd<K1>(K1 k1 = default)
            where K1 : unmanaged, ITypeNat
                => mod<K1,N2>() != 0;
    }
}