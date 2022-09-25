//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines a tabular span of dimension MxN
    /// </summary>
    /// <typeparam name="M">The row count type</typeparam>
    /// <typeparam name="N">The row count type</typeparam>
    /// <typeparam name="T">The span element type</typeparam>
     [CustomSpan("table")]
     public readonly ref struct TableSpan<M,N,T>
        where M : unmanaged, ITypeNat
        where N : unmanaged, ITypeNat
        where T : unmanaged
    {
        readonly Span<T> data;

        /// <summary>
        /// The number of rows in the structure
        /// </summary>
        public static int RowCount
            => nat32i<M>();

        /// <summary>
        /// The number of columns in the structure
        /// </summary>
        public static int ColCount
            => nat32i<N>();

        /// <summary>
        /// The number of cells in each row
        /// </summary>
        public static int RowLength
            => ColCount;

        /// <summary>
        /// The number of cells in each column
        /// </summary>
        public static int ColLength
            => RowCount;

        /// <summary>
        /// The total number of allocated elements
        /// </summary>
        public static int CellCount
            => RowLength * ColLength;

        /// <summary>
        /// Verifies correct source span length prior to backing store assignment
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="U">The source element type</typeparam>
        [MethodImpl(Inline)]
        public static TableSpan<M,N,T> CheckedTransfer(Span<T> src)
        {
            var len = src.Length;
            Require.invariant(len >= CellCount, () =>  $"length(src) = {len} < {CellCount} = SpanLength");
            return new TableSpan<M,N,T>(src);
        }

        [MethodImpl(Inline)]
        internal TableSpan(ref T src)
        {
            data = MemoryMarshal.CreateSpan(ref src, CellCount);
        }

        [MethodImpl(Inline)]
        internal TableSpan(Span<T> src)
        {
            var len = src.Length;
            Require.invariant(len == CellCount, () => $"length(src) = {len} != {CellCount} = SpanLength");
            data = src;
        }

        [MethodImpl(Inline)]
        internal TableSpan(T[] src)
        {
            Require.invariant(src.Length == CellCount, () => $"length(src) = {src.Length} != {CellCount} = SpanLength");
            data = src;
        }

        [MethodImpl(Inline)]
        internal TableSpan(T value)
        {
            this.data = new Span<T>(new T[CellCount]);
            this.data.Fill(value);
        }

        [MethodImpl(Inline)]
        internal TableSpan(ReadOnlySpan<T> src)
        {
            var len = src.Length;
            Require.invariant(src.Length == CellCount, () => $"length(src) = {len} != {CellCount} = SpanLength");
            data = src.ToArray();
        }

        public ref T Head
        {
            [MethodImpl(Inline)]
            get => ref MemoryMarshal.GetReference(data);
        }

        public ref T this[int r, int c]
        {
            [MethodImpl(Inline)]
            get => ref Unsafe.Add(ref Head, RowLength*r + c);
        }

        public ref T this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Unsafe.Add(ref Head, index);
        }

        /// <summary>
        /// Provides access to the underlying linear storage
        /// </summary>
        public Span<T> Data
        {
            [MethodImpl(Inline)]
            get => data;
        }

        public GridDim<M,N> Dim
            => default;

        [MethodImpl(Inline)]
        public T[] ToArray()
            => data.ToArray();

        [MethodImpl(Inline)]
        public void Fill(T value)
            => data.Fill(value);

        [MethodImpl(Inline)]
        public Span<T>.Enumerator GetEnumerator()
            => data.GetEnumerator();

        [MethodImpl(Inline)]
        public ref T GetPinnableReference()
            => ref data.GetPinnableReference();

        [MethodImpl(Inline)]
        public void CopyTo(Span<T> dst)
            => data.CopyTo(dst);

        [MethodImpl(Inline)]
        public bool TryCopyTo(Span<T> dst)
            => data.TryCopyTo(dst);

        [MethodImpl(Inline)]
        public TableSpan<M,N,T> Replicate()
            => new TableSpan<M,N,T>(data.ToArray());

        [MethodImpl(Inline)]
        bool IsRowHead(int index)
            => index == 0 || index % RowLength == 0;

        public TableSpan<I,J,T> SubSpan<I,J>((uint r, uint c) origin, GridDim<I,J> dim = default)
            where I : unmanaged, ITypeNat
            where J : unmanaged, ITypeNat
        {
            var  dst = TableSpans.alloc<I,J,T>();
            var curidx = 0;
            for(var i = origin.r; i < (origin.r + dim.I); i++)
            for(var j = origin.c; j < (origin.c + dim.J); j++)
                dst[curidx++] = this[(int)i,(int)j];

            return dst;
        }

        public ref NatSpan<M,T> Col(int col, ref NatSpan<M,T> dst)
        {
            Require.invariant(col >= 0 && col < ColCount, () => $"The column index {col} is out of range");

            for(var row = 0; row < ColLength; row++)
                dst[row] = data[row*RowLength + col];
            return ref dst;
        }

        [MethodImpl(Inline)]
        public NatSpan<N,T> Row(int row)
        {
            Require.invariant(row >= 0 && row < RowCount, () => $"The row index {row} is out of range");
            return data.Slice(row * RowLength, RowLength);
        }

        [MethodImpl(Inline)]
        public NatSpan<N,T> Row<I>()
            where I : unmanaged, ITypeNat
                => Row(nat32i<I>());

        public TableSpan<N,M,T> Transpose()
        {
            var dst = TableSpans.alloc<N,M,T>();
            for(var r = 0; r < RowCount; r++)
            for(var c = 0; c < ColCount; c++)
                dst[c, r] = this[r, c];
            return dst;
        }

        public override bool Equals(object rhs)
            => throw new NotSupportedException();

        public override int GetHashCode()
            => throw new NotSupportedException();

        public static implicit operator TableSpan<M,N,T>(T[] src)
            => new TableSpan<M,N,T>(src);

        public static implicit operator TableSpan<M,N,T>(Span<T> src)
            => new TableSpan<M,N,T>(src);

        public static implicit operator Span<T>(TableSpan<M,N,T> src)
            => src.data;

        public static implicit operator ReadOnlySpan<T> (TableSpan<M,N,T> src)
            => src.data;
    }
}