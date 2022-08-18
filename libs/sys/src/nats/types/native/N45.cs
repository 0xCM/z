//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 4549
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct N45 : INativeNatural, INatSeq<N45>
    {
        public const ulong Value = 45;

        public const string Text = "45";

        public static N45 Rep => default;

        public static NatSeq<N4,N5> Seq => default;

        [MethodImpl(Inline)]
        public static implicit operator int(N45 src) => 45;

        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();
    }
}