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
    /// Captures evidence that k % 2 != 0
    /// </summary>
    /// <typeparam name="K">An odd natural type</typeparam>
    public readonly struct NatOdd<K> : INatOdd<K>
        where K: unmanaged, ITypeNat
    {
        static K k => default;

        public static string Description => $"{k} % {2} != {0}";

        [MethodImpl(Inline)]
        public NatOdd(K k)
            => Require.invariant(NatCalc.odd(k), () => Description);

        public ulong NatValue
            => k.NatValue;

        public override string ToString()
            => Description;
    }
}