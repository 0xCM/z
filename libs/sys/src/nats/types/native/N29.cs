//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct N29 :
        INativeNatural,
        INatSeq<N29>
    {
        public const ulong Value = 29;

        public static N29 Rep => default;

        public static NatSeq<N2,N9> Seq => default;

        [MethodImpl(Inline)]
        public static implicit operator int(N29 src) => 29;

        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();
    }
}