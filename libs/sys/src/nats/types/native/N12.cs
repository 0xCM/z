//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using N = N12;

    public readonly struct N12 : INativeNatural, INatPrimitive<N>
    {
        public const ulong Value = 12;

        public const string Text = "12";

        public ulong NatValue
            => Value;

        public string NatText
            => Text;

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

        [MethodImpl(Inline)]
        public string Format()
            => Text;

        public override string ToString()
            => Text;
    }
}