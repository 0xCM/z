//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct N16384 :
        INativeNatural,
        INatSeq<N16384>,
        INatPow<N16384,N2,N14>,
        INatPow2<N14>,
        INatDivisible<N16384,N8192>,
        INatDivisible<N16384,N4096>,
        INatDivisible<N16384,N2048>,
        INatDivisible<N16384,N1024>,
        INatDivisible<N16384,N512>,
        INatDivisible<N16384,N256>,
        INatDivisible<N16384,N128>,
        INatDivisible<N16384,N64>,
        INatDivisible<N16384,N32>,
        INatDivisible<N16384,N16>,
        INatDivisible<N16384,N8>,
        INatDivisible<N16384,N4>
    {
        public const ulong Value = 1ul << 14;

        public static N16384 Rep => default;


        [MethodImpl(Inline)]
        public static implicit operator int(N16384 src) => 16384;

        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();
   }
}