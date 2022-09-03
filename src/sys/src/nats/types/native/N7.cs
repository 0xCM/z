//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using N = N7;

    /// <summary>
    /// The singleton type representative for 7
    /// </summary>
    public readonly struct N7 : INatPrimitive<N>, INativeNatural
    {
        public const ulong Value = 7;

        public const string Text = "7";

        public static N N => default;


        [MethodImpl(Inline)]
        public static implicit operator byte(N src)
            => (byte)Value;

        [MethodImpl(Inline)]
        public static implicit operator int(N src)
            => (int)Value;

        public ulong NatValue
            => Value;

        public string NatText
            => Text;

        [MethodImpl(Inline)]
        public string Format()
            => Text;

        public override string ToString()
            => Text;
    }
}