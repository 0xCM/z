//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct N28 : INativeNatural, INatPrimitive<N28>
    {
        public const ulong Value = 28;

        public static N28 Rep => default;

        public static NatSeq<N2,N8> Seq => default;

        [MethodImpl(Inline)]
        public static implicit operator int(N28 src) => 28;

        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();
    }
}