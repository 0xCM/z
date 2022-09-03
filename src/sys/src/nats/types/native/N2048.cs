//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct N2048 :
        INativeNatural,
        INatSeq<N2048>,
        INatPow<N2048,N2,N11>,
        INatPow2<N11>,
        INatDivisible<N2048,N1024>,
        INatDivisible<N2048,N512>,
        INatDivisible<N2048,N256>,
        INatDivisible<N2048,N128>,
        INatDivisible<N2048,N64>,
        INatDivisible<N2048,N32>,
        INatDivisible<N2048,N16>,
        INatDivisible<N2048,N8>,
        INatDivisible<N2048,N4>
    {
        public const ulong Value = 1ul << 11;

        [MethodImpl(Inline)]
        public static implicit operator int(N2048 src) => 2048;

        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();
    }
}