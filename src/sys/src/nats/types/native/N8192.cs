//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct N8192 :
        INativeNatural,
        INatSeq<N8192>,
        INatPow<N8192,N2,N13>,
        INatPow2<N13>,
        INatDivisible<N8192,N4096>,
        INatDivisible<N8192,N2048>,
        INatDivisible<N8192,N1024>,
        INatDivisible<N8192,N512>,
        INatDivisible<N8192,N256>,
        INatDivisible<N8192,N128>,
        INatDivisible<N8192,N64>,
        INatDivisible<N8192,N32>,
        INatDivisible<N8192,N16>,
        INatDivisible<N8192,N8>,
        INatDivisible<N8192,N4>

    {
        public const ulong Value = 1ul << 13;


        [MethodImpl(Inline)]
        public static implicit operator int(N8192 src) => 8192;

        public ulong NatValue => Value;


        public override string ToString()
            => Value.ToString();
   }


}