//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct N24 : INativeNatural, INatSeq<N24>, INatEven<N24>
    {
        public const ulong Value = 24;

        public static N24 Rep => default;

        [MethodImpl(Inline)]
        public static implicit operator int(N24 src) => 24;
        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();
    }
}