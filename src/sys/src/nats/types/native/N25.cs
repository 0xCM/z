//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct N25 : INativeNatural, INatSeq<N25>, INatDivisible<N25,N5>
    {
        public const ulong Value = 25;

        public static N25 Rep => default;

        [MethodImpl(Inline)]
        public static implicit operator int(N25 src) => 25;

        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();
    }
}