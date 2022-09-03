//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using N = N128;

    public readonly struct N128 :
        INativeNatural,
        INatSeq<N128>,
        INatPow<N128,N2,N7>,
        INatPow2<N7>,
        INatDivisible<N128,N4>,
        INatDivisible<N128,N8>,
        INatDivisible<N128,N16>,
        INatDivisible<N128,N32>,
        INatDivisible<N128,N64>
    {
        public const ulong Value = 128;

        public const string Text = "128";

        public static N N => default;

        [MethodImpl(Inline)]
        public static implicit operator int(N src)
            => (int)Value;

        public ulong NatValue
            => Value;

        [MethodImpl(Inline)]
        public string Format()
            => Text;

        public override string ToString()
             => Text;

        public static NatSeq<N1,N2,N8> Seq
            => default;
    }
}