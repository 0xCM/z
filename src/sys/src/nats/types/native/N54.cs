//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 5454
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct N54 : INativeNatural, INatSeq<N54,N5,N4>
    {
        public const ulong Value = 54;

        public static N54 Rep => default;


        [MethodImpl(Inline)]
        public static implicit operator int(N54 src) => 54;

        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();
    }
}