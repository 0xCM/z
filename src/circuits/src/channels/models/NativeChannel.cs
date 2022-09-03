//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = NativeFlows;

    public readonly struct NativeChannel : INativeChannel
    {
        /// <summary>
        /// The number of cells carried by the channel
        /// </summary>
        public uint CellCount {get;}

        /// <summary>
        /// The width of each cell
        /// </summary>
        public uint CellWidth {get;}

        /// <summary>
        /// The maximum channel width
        /// </summary>
        public uint Capacity {get;}

        /// <summary>
        /// The mask applied to source data, if any
        /// </summary>
        public ChannelMask Mask {get;}

        [MethodImpl(Inline)]
        internal NativeChannel(uint cells, uint width, ChannelMask mask = default)
        {
            CellCount = cells;
            CellWidth = width;
            Capacity = cells*width;
            Mask = mask;
        }

        public string Format()
            => api.format(this);


        public override string ToString()
            => Format();
    }
}