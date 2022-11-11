//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines a sequence of 32-bit cells
    /// </summary>
    public readonly struct HexVector32
    {
        readonly Index<Hex32> Data;

        [MethodImpl(Inline)]
        public HexVector32(Hex32[] src)
        {
            Data = src;
        }

        public ByteSize CellSize => 4;

        public BitWidth CellWidth => 32;

        public ByteSize VectorSize
        {
            [MethodImpl(Inline)]
            get => CellSize * CellCount;
        }

        public ref Hex32 this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public uint CellCount
        {
            [MethodImpl(Inline)]
            get => (uint)Data.Length;
        }

        public Span<Hex32> Cells
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ref Hex32 First
        {
            [MethodImpl(Inline)]
            get => ref Data.First;
        }

        [MethodImpl(Inline)]
        public static implicit operator HexVector32(Hex32[] src)
            => new HexVector32(src);
    }
}