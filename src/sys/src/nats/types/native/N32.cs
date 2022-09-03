//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using N = N32;

    public readonly struct N32 :
        INativeNatural,
        INatSeq<N32>,
        INatPow<N32,N2,N5>,
        INatPow2<N5>,
        INatDivisible<N32,N8>,
        INatDivisible<N32,N4>,
        INatDivisible<N32,N16>
    {
        public const ulong Value = 32;

        public static N N => default;

        public static NatSeq<N3,N2> Seq => default;

        [MethodImpl(Inline)]
        public static implicit operator int(N src) => 32;

        public ulong NatValue
            => Value;

        public override string ToString()
            => Value.ToString();
    }
}