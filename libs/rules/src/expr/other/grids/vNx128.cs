//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Expr
{
    using static core;

    /// <summary>
    /// Represents a finite sequence of 128-bit values
    /// </summary>
    public struct vNx128<T> : IVector<T>
        where T : unmanaged
    {
        readonly Index<T> Data;

        [MethodImpl(Inline)]
        internal vNx128(T[] cells)
        {
            Data = cells;
        }

        public Span<T> Cells
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        public ref T this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Cell(index);
        }

        public uint N
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        [MethodImpl(Inline)]
        public ref T Cell(uint index)
            => ref Data[index];
    }
}