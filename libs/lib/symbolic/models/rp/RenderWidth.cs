//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct RenderWidth : ITextual
    {
        public readonly ushort Value;

        [MethodImpl(Inline)]
        public RenderWidth(ushort value)
            => Value = value;

        [MethodImpl(Inline)]
        public string Format()
            => Value.ToString();

        public string Pattern()
            => RpOps.pad(-(int)Value);

        [MethodImpl(Inline)]
        public static implicit operator RenderWidth(int src)
            => new RenderWidth((ushort)src);

        [MethodImpl(Inline)]
        public static implicit operator RenderWidth(ushort src)
            => new RenderWidth(src);

        [MethodImpl(Inline)]
        public static implicit operator RenderWidth(uint src)
            => new RenderWidth((ushort)src);

        [MethodImpl(Inline)]
        public static explicit operator short(RenderWidth src)
            => (short)src.Value;

        [MethodImpl(Inline)]
        public static implicit operator int(RenderWidth src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator RenderWidth<ushort>(RenderWidth src)
            => src.Value;
    }
}