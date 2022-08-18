//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct N4096 :
        INativeNatural,
        INatSeq<N4096>,
        INatPow<N4096,N2,N12>,
        INatPow2<N12>,
        INatDivisible<N4096,N2048>,
        INatDivisible<N4096,N1024>,
        INatDivisible<N4096,N512>,
        INatDivisible<N4096,N256>,
        INatDivisible<N4096,N128>,
        INatDivisible<N4096,N64>,
        INatDivisible<N4096,N32>,
        INatDivisible<N4096,N16>,
        INatDivisible<N4096,N8>,
        INatDivisible<N4096,N4>
    {
        public const ulong Value = 1ul << 12;

        public static N4096 Rep => default;

        [MethodImpl(Inline)]
        public static implicit operator int(N4096 src) => 4096;

        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();
    }


}