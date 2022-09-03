//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 5151
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct N51 : INativeNatural, INatSeq<N51,N5,N1>
    {
        public const ulong Value = 51;

        public static N51 Rep => default;


        [MethodImpl(Inline)]
        public static implicit operator int(N51 src) => 51;

        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();
    }
}