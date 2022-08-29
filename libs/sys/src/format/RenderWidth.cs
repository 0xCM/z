//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = MsgOps;

    public readonly record struct RenderWidth : IDataType<RenderWidth>, IDataString
    {
        public readonly ushort Value;

        [MethodImpl(Inline)]
        public RenderWidth(ushort value)
            => Value = value;

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Value;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Value == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Value != 0;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(RenderWidth src)
            => Value == src.Value;

        [MethodImpl(Inline)]
        public int CompareTo(RenderWidth src)
            => Value.CompareTo(src.Value);

        [MethodImpl(Inline)]
        public string Format()
            => Value.ToString();

        public string Pattern()
            => api.pad(-(int)Value);

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