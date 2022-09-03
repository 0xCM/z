//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct NativeFiber<C> : INativeFiber<C>
        where C : unmanaged, INativeChannel
    {
        /// <summary>
        /// The channel over which the fiber is defined
        /// </summary>
        public C Channel;

        /// <summary>
        /// The selected cell
        /// </summary>
        public uint Cell;

        /// <summary>
        /// The offset of the fiber within the cell
        /// </summary>
        public ushort Offset;

        /// <summary>
        /// The fiber width
        /// </summary>
        public byte Width;

        [MethodImpl(Inline)]
        public NativeFiber(C src, uint cell = 0, ushort offset = 0, byte width = 0)
        {
            Cell = cell;
            Channel = src;
            Offset = offset;
            Width = width;
        }

        C INativeFiber<C>.Source
            => Channel;

        uint INativeFiber.Cell
            => Cell;

        ushort INativeFiber.Offset
            => Offset;

        byte INativeFiber.Width
            => Width;

        [MethodImpl(Inline)]
        public static implicit operator NativeFiber(NativeFiber<C> src)
            => new NativeFiber(new NativeChannel(src.Channel.CellCount, src.Channel.CellWidth, src.Channel.Mask), src.Cell, src.Offset, src.Width);
    }
}
