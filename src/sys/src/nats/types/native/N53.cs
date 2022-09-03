//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 5353
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct N53 : INativeNatural, INatSeq<N53,N3,N2>
    {
        public const ulong Value = 53;

        public static N53 Rep => default;

        [MethodImpl(Inline)]
        public static implicit operator int(N53 src) => 53;

        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();
    }
}