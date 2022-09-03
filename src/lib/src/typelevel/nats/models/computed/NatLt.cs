//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Captures evidence k1 < k2
    /// </summary>
    public readonly struct NatLt<K1,K2> : INatLt<K1,K2>
        where K1: unmanaged, ITypeNat
        where K2: unmanaged, ITypeNat
    {
        static K1 k1 => default;

        static K2 k2 => default;

        public static string Description => $"{k1} < {k2}";

        [MethodImpl(Inline)]
        public NatLt(K1 n1, K2 n2)
            => Require.invariant(n1.NatValue < n2.NatValue, () => Description);

        public override string ToString()
            => Description;
    }
}