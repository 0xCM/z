//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using N = N1024;

    public readonly struct N1024 :
        INativeNatural,
        INatSeq<N>,
        INatPow<N,N2,N10>,
        INatPow2<N10>,
        INatDivisible<N,N4>,
        INatDivisible<N,N8>,
        INatDivisible<N,N16>,
        INatDivisible<N,N32>,
        INatDivisible<N,N64>,
        INatDivisible<N,N128>,
        INatDivisible<N,N512>,
        INatDivisible<N,N256>
    {
        public const ulong Value = 1ul << 10;

        [MethodImpl(Inline)]
        public static implicit operator int(N src) => 1024;

        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();
    }
}