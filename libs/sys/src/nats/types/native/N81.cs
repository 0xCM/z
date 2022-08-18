//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using N = N81;

    public readonly struct N81 : INativeNatural, INatSeq<N81,N8,N1>
    {
        public const ulong Value = 81;

        public static N Rep => default;

        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();

        [MethodImpl(Inline)]
        public static implicit operator int(N src)
            => (int)Value;
    }
}