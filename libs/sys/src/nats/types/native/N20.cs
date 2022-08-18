//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using N = N20;

    public readonly struct N20 : INativeNatural, INatPrimitive<N>
    {
        public const ulong Value = 20;

        public const string Text = "20";

        public static N N => default;

        [MethodImpl(Inline)]
        public static implicit operator int(N src)
            => (int)Value;

        [MethodImpl(Inline)]
        public static implicit operator byte(N src)
            => (byte)Value;

        [MethodImpl(Inline)]
        public static implicit operator ushort(N src)
            => (ushort)Value;

        [MethodImpl(Inline)]
        public static implicit operator uint(N src)
            => (uint)Value;

        [MethodImpl(Inline)]
        public static implicit operator ulong(N src)
            => Value;

        public uint Hash
            => (uint)Value;

        public override int GetHashCode()
            => (int)Hash;

        public ulong NatValue
            => Value;

        public string NatText
            => Text;

        [MethodImpl(Inline)]
        public string Format()
            => Text;

        public override string ToString()
            => Format();
    }
}