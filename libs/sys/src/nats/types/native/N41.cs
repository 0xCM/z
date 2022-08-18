//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2119
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct N41 : INativeNatural, INatSeq<N41>
    {
        public const ulong Value = 41;

        public static N41 Rep => default;

        public static NatSeq<N4,N1> Seq => default;

        [MethodImpl(Inline)]
        public static implicit operator int(N41 src) => 41;

        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();
    }
}