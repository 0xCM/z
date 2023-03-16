//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct AsciGrid<K>
        where K : unmanaged
    {
        readonly AsciSeq _Data;

        public readonly uint RowWidth;

        [MethodImpl(Inline)]
        public AsciGrid(AsciSeq src, uint rows)
        {
            _Data = src;
            RowWidth = rows;
        }

        public ReadOnlySpan<byte> Rows
        {
            [MethodImpl(Inline)]
            get => _Data.View;
        }

        public uint RowCount
        {
            [MethodImpl(Inline)]
            get => (uint)(_Data.Capacity/RowWidth);
        }

        [MethodImpl(Inline)]
        public ReadOnlySpan<byte> Row(uint index)
                => sys.slice(Rows, index*RowWidth, RowWidth);

        public string Format()
            => _Data.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AsciGrid(AsciGrid<K> src)
            => new AsciGrid(src._Data, src.RowWidth);
    }
}