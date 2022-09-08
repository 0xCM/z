//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [StructLayout(LayoutKind.Sequential, Pack=1), Closures(UnsignedInts)]
    public readonly struct GridDim<T> : IEquatable<GridDim<T>>
        where T : unmanaged
    {
        public readonly T RowCount;

        public readonly T ColCount;

        [MethodImpl(Inline)]
        public GridDim(T rows, T cols)
        {
            RowCount = rows;
            ColCount = cols;
        }

        public ulong CellCount
        {
            [MethodImpl(Inline)]
            get => u64(RowCount) * u64(ColCount);
        }

        /// <summary>
        /// Formats the dimension in canonical form
        /// </summary>
        public string Format()
            => $"{RowCount}x{ColCount}";

        [MethodImpl(Inline)]
        public void Deconstruct(out T rows, out T cols)
        {
            rows = RowCount;
            cols = ColCount;
        }

        [MethodImpl(Inline)]
        public static implicit operator GridDim<T>((T rows, T cols) src)
            => new GridDim<T>(src.rows,src.cols);

        [MethodImpl(Inline)]
        public bool Equals(GridDim<T> src)
            => u64(src.RowCount) == u64(RowCount)
            && u64(src.ColCount) == u64(ColCount);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)alg.hash.combine(u32(RowCount), u32(ColCount));

        public override bool Equals(object obj)
            => obj is GridDim d && Equals(d);

        public static bool operator ==(GridDim<T> d1, GridDim<T> d2)
            => d1.Equals(d2);

        public static bool operator !=(GridDim<T> d1, GridDim<T> d2)
            => !d1.Equals(d2);

        public static GridDim<T> Empty
            => default;
    }
}