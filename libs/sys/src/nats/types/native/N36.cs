//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct N36 :
        INativeNatural,
        INatSeq<N36>,
        INatEven<N36>,
        INatDivisible<N36,N6>,
        INatDivisible<N36,N12>
    {
        public const ulong Value = 36;

        public static N36 Rep => default;

        public static NatSeq<N3,N6> Seq => default;

        [MethodImpl(Inline)]
        public static implicit operator int(N36 src) => 36;

        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();
    }
}