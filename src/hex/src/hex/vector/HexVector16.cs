//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines a sequence of 16-bit cells
    /// </summary>
    public readonly struct HexVector16
    {
        readonly Index<Hex16> Data;

        [MethodImpl(Inline)]
        public HexVector16(Hex16[] src)
        {
            Data = src;
        }

        public ByteSize CellSize => 2;

        public BitWidth CellWidth => 16;

        public ByteSize VectorSize
        {
            [MethodImpl(Inline)]
            get => CellSize * CellCount;
        }

        public ref Hex16 this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public uint CellCount
        {
            [MethodImpl(Inline)]
            get => (uint)Data.Length;
        }

        public Span<Hex16> Cells
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ref Hex16 First
        {
            [MethodImpl(Inline)]
            get => ref Data.First;
        }

        [MethodImpl(Inline)]
        public static implicit operator HexVector16(Hex16[] src)
            => new HexVector16(src);
    }
}