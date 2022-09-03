//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct N33 : INativeNatural, INatSeq<N33>, INatPrime<N11>
    {
        public const ulong Value = 33;

        public static N33 Rep => default;

        public static NatSeq<N3,N3> Seq => default;

        [MethodImpl(Inline)]
        public static implicit operator int(N33 src) => 33;

        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();
    }
}