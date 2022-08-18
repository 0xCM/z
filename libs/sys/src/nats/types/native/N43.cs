//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 3339
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct N43 : INativeNatural, INatSeq<N43,N4,N3>
    {
        public const ulong Value = 43;

        public static N43 Rep => default;

        [MethodImpl(Inline)]
        public static implicit operator int(N43 src) => 43;

        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();
    }
}