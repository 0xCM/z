//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct N40 : INativeNatural, INatSeq<N40>
    {
        public const ulong Value = 40;

        public static N40 Rep => default;

        public static NatSeq<N4,N0> Seq => default;

        [MethodImpl(Inline)]
        public static implicit operator int(N40 src) => 40;

        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();
    }
}