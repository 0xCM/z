//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using N = N16;
    public readonly struct N16 :
        INativeNatural,
        INatNumber<N>,
        INatPrior<N,N15>,
        INatSeq<N>,
        INatPow<N,N2,N4>,
        INatPow2<N4>,
        INatDivisible<N,N8>,
        INatDivisible<N,N4>
    {
        public const ulong Value = 16;

        public const string Text = "16";

        public ulong NatValue
            => Value;

        [MethodImpl(Inline)]
        public static implicit operator int(N src)
            => (int)Value;

        [MethodImpl(Inline)]
        public string Format()
            => Text;

        public override string ToString()
            => Text;
    }
}