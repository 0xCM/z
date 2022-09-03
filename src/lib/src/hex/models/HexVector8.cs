//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines a sequence of 8-bit cells
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct HexVector8
    {
        readonly Index<Hex8> Data;

        [MethodImpl(Inline)]
        public HexVector8(Hex8[] data)
        {
            Data = data;
        }

        public ByteSize CellSize => 1;

        public BitWidth CellWidth => 8;

        public uint CellCount
        {
            [MethodImpl(Inline)]
            get => (uint)Data.Length;
        }

        public ByteSize VectorSize
        {
            [MethodImpl(Inline)]
            get => CellSize * CellCount;
        }

        public Span<Hex8> Cells
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ref Hex8 First
        {
            [MethodImpl(Inline)]
            get => ref Data.First;
        }

        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => bytes(Data);
        }

        public ref Hex8 this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        [MethodImpl(Inline)]
        public static implicit operator HexVector8(Hex8[] src)
            => new HexVector8(src);
    }
}