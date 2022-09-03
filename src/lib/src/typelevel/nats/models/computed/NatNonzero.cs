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
    /// Captures evidence that k != 0
    /// </summary>
    /// <typeparam name="K">A nonzero natural type</typeparam>
    public readonly struct NatNonzero<K> : INonZeroNat<K>
        where K: unmanaged, ITypeNat
    {
        static K k => default;

        public static string Description => $"{k} != 0";

        public ulong NatValue => TypeNats.value(k);

        [MethodImpl(Inline)]
        public NatNonzero(K n)
            => Require.invariant(n.NatValue != 0, () => Description);

        public override string ToString()
            => Description;
    }
}