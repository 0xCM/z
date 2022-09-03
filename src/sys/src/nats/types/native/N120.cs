//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct N120 : INativeNatural, INatSeq<N120,N1,N2,N0>
    {
        public const ulong Value = 120;

        [MethodImpl(Inline)]
        public static implicit operator int(N120 src)
            => (int)Value;

        public ulong NatValue => Value;


        public override string ToString()
            => Value.ToString();
    }
}