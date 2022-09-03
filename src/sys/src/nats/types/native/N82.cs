//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using N = N82;

    public readonly struct N82 : INativeNatural, INatSeq<N82,N8,N2>
    {
        public const ulong Value = 82;

        public static N Rep => default;

        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();

        [MethodImpl(Inline)]
        public static implicit operator int(N src)
            => (int)Value;
    }
}