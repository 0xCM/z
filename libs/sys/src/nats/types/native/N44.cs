//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 4449
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct N44 : INativeNatural, INatSeq<N44>
    {
        public const ulong Value = 44;

        public static N44 Rep => default;


        [MethodImpl(Inline)]
        public static implicit operator int(N44 src) => 44;

        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();
    }
}