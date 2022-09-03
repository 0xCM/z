//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = NativeFlows;

    public readonly struct NativeChannel<W> : INativeChannel<W>
        where W : unmanaged, ITypeWidth
    {
        /// <summary>
        /// The number of cells carried by the channel
        /// </summary>
        public uint CellCount {get;}

        /// <summary>
        /// The width of each cell
        /// </summary>
        public uint CellWidth
        {
            [MethodImpl(Inline)]
            get => core.width<W>();
        }

        public uint Capacity {get;}

        public ChannelMask Mask {get;}

        [MethodImpl(Inline)]
        internal NativeChannel(uint cells, ChannelMask mask = default)
        {
            CellCount = cells;
            Capacity = cells*core.width<W>();
            Mask = mask;
        }

        public string Format()
            => api.format(this);


        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator NativeChannel(NativeChannel<W> src)
            => api.channel(src.CellCount, src.CellWidth, src.Mask);
    }
}