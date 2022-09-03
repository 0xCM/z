//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct N37 :
        INativeNatural,
        INatSeq<N37>
    {
        public const ulong Value = 37;

        public static N37 Rep => default;

        public ulong NatValue
            => Value;

        [MethodImpl(Inline)]
        public static implicit operator int(N37 src) => 37;


        public override string ToString()
            => Value.ToString();
    }
}