//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 4949
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct N49 : INativeNatural, INatSeq<N49>
    {
        public const ulong Value = 49;

        public static N49 Rep => default;

        public static NatSeq<N4,N9> Seq => default;

        [MethodImpl(Inline)]
        public static implicit operator int(N49 src) => 49;

        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();
    }
}