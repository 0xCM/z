//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines a natural sequence of 16-bit cells
    /// </summary>
    public readonly struct HexVector16<N>
        where N : unmanaged, ITypeNat
    {
        readonly Index<Hex16> Data;

        [MethodImpl(Inline)]
        public HexVector16(Hex16[] data)
        {
            Data = data;
        }

        public static ByteSize CellSize => 2;

        public static BitWidth CellWidth => 16;

        public static uint CellCount
        {
            [MethodImpl(Inline)]
            get => (uint)Typed.value<N>();
        }

        public static ByteSize VectorSize
        {
            [MethodImpl(Inline)]
            get => CellCount*CellSize;
        }

        public static BitWidth VectorWidth
        {
            [MethodImpl(Inline)]
            get => CellCount*CellWidth;
        }

        public ref Hex16 this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        [MethodImpl(Inline)]
        public static implicit operator HexVector16(HexVector16<N> src)
            => new HexVector16(src.Data);
    }
}