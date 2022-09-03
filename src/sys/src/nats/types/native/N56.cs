//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct N56 : INativeNatural, INatSeq<N56,N5,N6>
    {
        public const ulong Value = 56;

        public static NatSeq<N5,N6> Seq => default;

        [MethodImpl(Inline)]
        public static implicit operator int(N56 src) => 56;

        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();
    }
}