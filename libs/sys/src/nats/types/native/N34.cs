//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct N34 : INativeNatural, INatSeq<N34>
    {
        public const ulong Value = 34;

        public static N34 Rep => default;

        public static NatSeq<N3,N4> Seq => default;

        [MethodImpl(Inline)]
        public static implicit operator int(N34 src) => 34;

        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();
    }
}