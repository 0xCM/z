//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct NativeFiber : INativeFiber
    {
        /// <summary>
        /// The channel over which the fiber is defined
        /// </summary>
        public NativeChannel Channel;

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
        public NativeFiber(NativeChannel src, uint cell = 0, ushort offset = 0, byte width = 0)
        {
            Cell = cell;
            Channel = src;
            Offset = offset;
            Width = width;
        }

        INativeChannel INativeFiber.Source
            => Channel;

        uint INativeFiber.Cell
            => Cell;

        ushort INativeFiber.Offset
            => Offset;

        byte INativeFiber.Width
            => Width;
    }
}