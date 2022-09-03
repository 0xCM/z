//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct N60 : INativeNatural, INatSeq<N60,N6,N0>
    {
        public const ulong Value = 60;

        [MethodImpl(Inline)]
        public static implicit operator int(N60 src) => 60;

        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();
    }
}