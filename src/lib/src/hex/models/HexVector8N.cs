//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines a natural sequence of 8-bit cells
    /// </summary>
    public readonly struct HexVector8<N>
        where N : unmanaged, ITypeNat
    {
        static N count => default;

        readonly Index<Hex8> Data;

        [MethodImpl(Inline)]
        public HexVector8(Hex8[] data)
        {
            Data = data;
        }


        public Span<Hex8> Edit
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        public ReadOnlySpan<Hex8> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public static ByteSize CellSize => 1;

        public static BitWidth CellWidth => 8;

        public static uint CellCount
        {
            [MethodImpl(Inline)]
            get => (uint)count.NatValue;
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

        public ref Hex8 this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref Hex8 this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        [MethodImpl(Inline), Op]
        public uint Bitstring(uint offset, Span<char> dst)
            => BitRender.bitstring(this, offset, dst, count);

        public string Format()
            => string.Format("<{0}>", sys.bytes(View).FormatHex());

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator HexVector8(HexVector8<N> src)
            => new HexVector8(src.Data);
    }
}