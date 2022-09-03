//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct FlowWire
    {
        public readonly byte Width;

        [MethodImpl(Inline)]
        public FlowWire(byte width)
        {
            Width = width;
        }

        [MethodImpl(Inline)]
        public static implicit operator FlowWire(uint width)
            => new FlowWire((byte)width);

        [MethodImpl(Inline)]
        public static implicit operator FlowWire(byte width)
            => new FlowWire(width);

        public string Format()
            => Width.ToString();

        public override string ToString()
            => Format();
    }
}