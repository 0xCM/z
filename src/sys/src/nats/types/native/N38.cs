//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct N38 : INativeNatural, INatSeq<N38>
    {
        public const ulong Value = 38;

        public static N38 Rep => default;

        public static NatSeq<N3,N8> Seq => default;

        [MethodImpl(Inline)]
        public static implicit operator int(N38 src) => 38;

        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();
    }
}