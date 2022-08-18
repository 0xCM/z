//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct N39 : INativeNatural, INatSeq<N39>
    {
        public const ulong Value = 39;

        public static N39 Rep => default;

        public static NatSeq<N3,N9> Seq => default;

        [MethodImpl(Inline)]
        public static implicit operator int(N39 src) => 39;

        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();
    }
}