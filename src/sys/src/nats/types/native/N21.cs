//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using N = N21;

    public readonly struct N21 : INativeNatural, INatPrimitive<N>
    {
        public const ulong Value = 21;

        public static N21 Rep => default;

        public static NatSeq<N2,N1> Seq => default;

        [MethodImpl(Inline)]
        public static implicit operator int(N21 src) => 21;

        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();
    }
}