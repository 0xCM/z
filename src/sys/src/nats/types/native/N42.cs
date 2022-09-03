//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2229
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct N42 : INativeNatural, INatSeq<N42>
    {
        public const ulong Value = 42;

        public static N42 Rep => default;

        [MethodImpl(Inline)]
        public static implicit operator int(N42 src) => 42;

        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();
    }
}