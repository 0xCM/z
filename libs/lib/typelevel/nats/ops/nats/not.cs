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
        /// Computes k := ~k1
        /// </summary>
        [MethodImpl(Inline)]
        public static ulong not<K1>(K1 k1 = default)
            where K1 : unmanaged, ITypeNat
                => ~ value(k1);
    }
}