//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using N = N83;

    public readonly struct N83 : INativeNatural, INatSeq<N,N8,N3>
    {
        public const ulong Value = 83;

        public static N Rep => default;

        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();

        [MethodImpl(Inline)]
        public static implicit operator int(N src)
            => (int)Value;
    }
}