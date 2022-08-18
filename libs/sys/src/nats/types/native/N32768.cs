//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct N32768 :
        INativeNatural,
        INatSeq<N32768>,
        INatPow<N32768,N2,N15>,
        INatPow2<N15>,
        INatDivisible<N32768,N16384>,
        INatDivisible<N32768,N8192>,
        INatDivisible<N32768,N4096>,
        INatDivisible<N32768,N2048>,
        INatDivisible<N32768,N1024>,
        INatDivisible<N32768,N512>,
        INatDivisible<N32768,N256>,
        INatDivisible<N32768,N128>,
        INatDivisible<N32768,N64>,
        INatDivisible<N32768,N32>,
        INatDivisible<N32768,N16>,
        INatDivisible<N32768,N8>,
        INatDivisible<N32768,N4>

    {
        public const ulong Value = 1ul << 15;


        [MethodImpl(Inline)]
        public static implicit operator int(N32768 src) => 32768;

        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();
   }
}