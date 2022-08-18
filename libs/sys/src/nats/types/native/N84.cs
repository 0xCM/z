//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using N = N84;

    public readonly struct N84 : INativeNatural, INatSeq<N84,N8,N4>
    {
        public const ulong Value = 84;

        public static N Rep => default;

        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();

        [MethodImpl(Inline)]
        public static implicit operator int(N src)
            => (int)Value;
    }
}