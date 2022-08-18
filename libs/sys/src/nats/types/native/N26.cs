//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    public readonly struct N26 : INativeNatural, INatSeq<N26,N2,N6>
    {
        public const ulong Value = 26;

        public static N26 Rep => default;

        [MethodImpl(Inline)]
        public static implicit operator int(N26 src) => 26;

        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();
    }
}