//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct N35 : INativeNatural, INatPrimitive<N35>
    {
        public const ulong Value = 35;

        public static N35 Rep => default;

        public static NatSeq<N3,N5> Seq => default;

        [MethodImpl(Inline)]
        public static implicit operator int(N35 src) => 35;

        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();
    }
}