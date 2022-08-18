//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using N = N15;

    public readonly struct N15 : INatPrimitive<N>, INativeNatural
    {
        public const ulong Value = 15;

        public const string Text = "15";

        public ulong NatValue
            => Value;

        public string NatText
            => Text;

        [MethodImpl(Inline)]
        public static implicit operator int(N15 src)
            => (int)Value;

        [MethodImpl(Inline)]
        public static implicit operator byte(N15 src)
            => (byte)Value;

        [MethodImpl(Inline)]
        public static implicit operator ushort(N15 src)
            => (ushort)Value;

        [MethodImpl(Inline)]
        public static implicit operator uint(N15 src)
            => (uint)Value;

        [MethodImpl(Inline)]
        public static implicit operator ulong(N15 src)
            => Value;

        [MethodImpl(Inline)]
        public string Format()
            => Text;

        public override string ToString()
            => Text;
    }
}