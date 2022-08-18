//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using N = N8;

    /// <summary>
    /// The singleton type representative for 8
    /// </summary>
    public readonly struct N8 : INatPrimitive<N>, INativeNatural
    {
        public const ulong Value = 8;

        public const string Text = "8";

        public static N N => default;

        [MethodImpl(Inline)]
        public static implicit operator int(N src)
            => (int)Value;

        [MethodImpl(Inline)]
        public static implicit operator byte(N src)
            => (byte)Value;

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