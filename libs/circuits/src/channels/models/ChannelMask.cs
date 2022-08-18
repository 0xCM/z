//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = NativeFlows;

    public readonly struct ChannelMask : IChannelMask<ChannelMask>
    {
        public ulong Value {get;}

        public ChannelMaskKind Kind {get;}

        [MethodImpl(Inline)]
        public ChannelMask(ChannelMaskKind kind, ulong value)
        {
            Kind = kind;
            Value = value;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Kind == 0 || Value == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Kind != 0;
        }

        public string Format()
            => api.format(this);


        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ChannelMask((ChannelMaskKind kind, ulong value) src)
            => new ChannelMask(src.kind, src.value);

        [MethodImpl(Inline)]
        public static implicit operator ChannelMask(Paired<ChannelMaskKind,ulong> src)
            => new ChannelMask(src.Left, src.Right);

        public static ChannelMask Empty => default;
    }
}