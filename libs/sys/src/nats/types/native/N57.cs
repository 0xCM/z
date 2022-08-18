//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct N57 : INativeNatural, INatSeq<N57,N5,N7>
    {
        public const ulong Value = 57;

        [MethodImpl(Inline)]
        public static implicit operator int(N57 src) => 57;

        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();
    }
}