//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using N = N4;

    /// <summary>
    /// The singleton type representative for 4
    /// </summary>
    public readonly struct N4  : INatPrimitive<N>, INativeNatural
    {
        public const ulong Value = 4;

        public const string Text = "4";

        public static N N => default;

        [MethodImpl(Inline)]
        public static implicit operator byte(N src)
            => (byte)Value;

        [MethodImpl(Inline)]
        public static implicit operator int(N src)
            => (int)Value;

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