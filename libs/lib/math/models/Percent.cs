//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a datatype that represents a discrete percentage
    /// </summary>
    public record struct Percent
    {
        public Quotient<uint> Value;

        public static Percent Zero => default;

        [MethodImpl(Inline)]
        public Percent(uint over, uint under)
            => Value = (over,under);

        [MethodImpl(Inline)]
        public uint Div()
            => Value.Over/Value.Under;

        [MethodImpl(Inline)]
        public uint Rem()
            => Value.Over%Value.Under;

        [MethodImpl(Inline)]
        public string Format()
            => Div().ToString();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Percent((uint over, uint under) src)
            => new Percent(src.over, src.under);

        [MethodImpl(Inline)]
        public static implicit operator Percent(Pair<uint> src)
            => new Percent(src.Left, src.Right);
    }
}