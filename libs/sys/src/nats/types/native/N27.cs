//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct N27 : INativeNatural, INatSeq<N27>
    {
        public const ulong Value = 27;

        public static N27 Rep => default;

        [MethodImpl(Inline)]
        public static implicit operator int(N27 src) => 27;

        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();
    }
}