//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using N = N512;

    public readonly struct N512 :
        INativeNatural,
        INatSeq<N>,
        INatPow<N,N2,N9>,
        INatPow2<N9>,
        INatDivisible<N,N256>,
        INatDivisible<N,N128>,
        INatDivisible<N,N64>,
        INatDivisible<N,N32>,
        INatDivisible<N,N16>,
        INatDivisible<N,N8>,
        INatDivisible<N,N4>
    {
        public const ulong Value = 1ul << 9;

        [MethodImpl(Inline)]
        public static implicit operator int(N src) => 512;

        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();
    }
}