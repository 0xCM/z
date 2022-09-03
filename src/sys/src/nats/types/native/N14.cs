//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using N = N14;

    public readonly struct N14 : INativeNatural, INatPrimitive<N>
    {
        public const ulong Value = 14;

        public const string Text = "14";

        public ulong NatValue
            => Value;

        public string NatText
            => Text;

        [MethodImpl(Inline)]
        public static implicit operator int(N14 src)
            => (int)Value;

        [MethodImpl(Inline)]
        public static implicit operator byte(N14 src)
            => (byte)Value;

        [MethodImpl(Inline)]
        public static implicit operator ushort(N14 src)
            => (ushort)Value;

        [MethodImpl(Inline)]
        public static implicit operator uint(N14 src)
            => (uint)Value;

        [MethodImpl(Inline)]
        public static implicit operator ulong(N14 src)
            => Value;

        [MethodImpl(Inline)]
        public string Format()
            => Text;

        public override string ToString()
            => Text;
    }
}