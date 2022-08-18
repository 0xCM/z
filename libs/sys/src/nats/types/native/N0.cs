//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using N = N0;

    /// <summary>
    /// The singleton type representative for 0
    /// </summary>
    public readonly struct N0 : INat0<N>, INativeNatural
    {
        public const ulong Value = 0;

        public const string Text = "0";

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
            => Text;
    }
}