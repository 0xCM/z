//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = LookupTables;

    /// <summary>
    /// Defines a <see cref='LookupKey'/> sequence over a 2-d grid
    /// </summary>
    public readonly struct LookupKeys
    {
        public GridDim<ushort> Dim {get;}

        readonly Index<LookupKey> Data;

        [MethodImpl(Inline)]
        internal LookupKeys(GridDim<ushort> dim, LookupKey[] src)
        {
            Dim = dim;
            Data = src;
        }

        public ushort RowCount
        {
            [MethodImpl(Inline)]
            get => Dim.RowCount;
        }

        public ushort ColCount
        {
            [MethodImpl(Inline)]
            get => Dim.ColCount;
        }

        public ref readonly LookupKey this[ushort row, ushort col]
        {
            [MethodImpl(Inline)]
            get => ref api.key(this, row, col);
        }

        internal ReadOnlySpan<LookupKey> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }
    }
}