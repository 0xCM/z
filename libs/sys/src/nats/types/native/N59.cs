//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct N59 : INativeNatural, INatSeq<N59,N5,N9>
    {
        public const ulong Value = 59;

        [MethodImpl(Inline)]
        public static implicit operator int(N59 src) => 59;

        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();
    }
}