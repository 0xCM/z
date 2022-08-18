//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct N30 : INativeNatural, INatSeq<N30>
    {
        public const ulong Value = 30;

        public static N30 Rep => default;

        public static NatSeq<N3,N0> Seq => default;

        [MethodImpl(Inline)]
        public static implicit operator int(N30 src) => 30;

        public ulong NatValue => 30;

        public override string ToString()
            => Value.ToString();
    }
}