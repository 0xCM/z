//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 5252
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct N52 : INativeNatural, INatSeq<N52,N5,N2>
    {
        public const ulong Value = 52;

        public static N52 Rep => default;

        [MethodImpl(Inline)]
        public static implicit operator int(N52 src) => 52;

        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();
    }
}