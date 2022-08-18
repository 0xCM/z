//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using N = N23;

    public readonly struct N23 : INativeNatural, INatPrimitive<N>
    {
        public const ulong Value = 23;

        public const string Text = "23";

        public static N N  => default;

        [MethodImpl(Inline)]
        public static implicit operator int(N23 src)
            => (int)Value;

        public ulong NatValue
            => Value;

        public string NatText
            => Text;

        public override string ToString()
            => Text;
    }
}