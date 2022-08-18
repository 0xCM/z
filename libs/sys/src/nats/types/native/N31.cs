//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct N31 : INativeNatural, INatSeq<N31>
    {
        public const ulong Value = 31;

        public static N31 Rep => default;

        public static NatSeq<N3,N1> Seq => default;

        [MethodImpl(Inline)]
        public static implicit operator int(N31 src) => 31;

        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();
    }
}