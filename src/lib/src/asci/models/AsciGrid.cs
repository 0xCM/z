//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct AsciGrid
    {
        readonly AsciSeq Data;

        public readonly uint RowWidth;

        public readonly uint RowCount;

        [MethodImpl(Inline)]
        public AsciGrid(AsciSeq src, uint width)
        {
            RowCount = src.Capacity/width;
            RowWidth = width;
            Data = src;
        }

        public ReadOnlySpan<byte> Rows
        {
            [MethodImpl(Inline)]
            get => Data.Data;
        }

        [MethodImpl(Inline)]
        public ReadOnlySpan<byte> Row(uint index)
            => AsciG.row(this, index);

        public string Format()
            => Data.Format();

        public override string ToString()
            => Format();
    }
}