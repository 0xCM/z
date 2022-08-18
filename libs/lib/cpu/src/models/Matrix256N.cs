//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a primal square matrix of natural order
    /// </summary>
    /// <typeparam name="N">The order type</typeparam>
    /// <typeparam name="T">The primal type</typeparam>
    public readonly ref struct Matrix256<N,T>
        where N : unmanaged, ITypeNat
        where T : unmanaged
    {
        readonly SpanBlock256<T> data;

        /// <summary>
        /// The square matrix dimension
        /// </summary>
        public static int Order
            => (int)Typed.nat64u<N>();

        /// <summary>
        /// The total number of allocated elements
        /// </summary>
        public static int CellCount
            => (int)NatCalc.square<N>();

        [MethodImpl(Inline)]
        public Matrix256(SpanBlock256<T> src)
        {
            var count = src.CellCount;
            Require.invariant(src.CellCount >= CellCount, () => $"{count} != {CellCount}");
            data = src;
        }

        [MethodImpl(Inline)]
        public ref T Cell(int r, int c)
            => ref data[Order*r + c];

        public ref T this[int r, int c]
        {
            [MethodImpl(Inline)]
            get => ref Cell(r,c);
        }

        public ref T this[uint r, uint c]
        {
            [MethodImpl(Inline)]
            get => ref Cell((int)r,(int)c);
        }

        [MethodImpl(Inline)]
        public Block256<N,T> Row(int row)
        {
            if(row < 0 || row >= Order)
                throw AppErrors.IndexOutOfRange(row, 0, Order - 1);

            return RowVectors.blockload<N,T>(data.Slice(row * Order, Order));
        }

        [MethodImpl(Inline)]
        public ref Block256<N,T> Row(int row, ref Block256<N,T> dst)
        {
            if(row < 0 || row >= Order)
                AppErrors.ThrowOutOfRange(row, 0, Order - 1);

             var src = data.Slice(row * Order, Order);
             src.CopyTo(dst.Unsized);
             return ref dst;
        }

        public ref Block256<N,T> Col(int col, ref Block256<N,T> dst)
        {
            if(col < 0 || col >= Order)
                AppErrors.ThrowOutOfRange(col, 0, Order - 1);

            for(var row = 0; row < Order; row++)
                dst[row] = data[row*Order + col];
            return ref dst;
        }

        [MethodImpl(Inline)]
        public Block256<N,T> Col(int col)
        {
            var alloc = RowVectors.blockalloc<N,T>();
            return Col(col, ref alloc);
        }

        /// <summary>
        /// Provides access to the underlying data as a linear unblocked span
        /// </summary>
        public Span<T> Unblocked
        {
            [MethodImpl(Inline)]
            get => data;
        }

        /// <summary>
        /// Provides access to the underlying data as a 256-bit blocked span
        /// </summary>
        public SpanBlock256<T> Unsized
        {
            [MethodImpl(Inline)]
            get => data;
        }

        /// <summary>
        /// Provides access to the underlying data as a span of natural dimensions
        /// </summary>
        public NatSpan<N,T> Natural
        {
            [MethodImpl(Inline)]
            get => Matrix.natspan<N,T>(data);
        }

        /// <summary>
        /// Applies a function to each cell and overwites the existing cell value with the result
        /// </summary>
        /// <param name="f">The function to apply</param>
        public void Apply(Func<T,T> f)
        {
            for(var r = 0; r < Order; r++)
            for(var c = 0; c < Order; c++)
                this[r,c] = f(this[r,c]);
        }


        public bool Equals(Matrix256<N,T> rhs)
        {
            for(var r = 0; r < Order; r ++)
            for(var c = 0; c < Order; c ++)
                if(!gmath.eq(this[r,c], rhs[r,c]))
                    return false;
            return true;
        }


        [MethodImpl(Inline)]
        public Matrix256<N,N,T> ToRectangular()
            => new Matrix256<N,N,T>(this.data);

        [MethodImpl(Inline)]
        public ref Matrix256<N,T> CopyTo(ref Matrix256<N,T> dst)
        {
            Unblocked.CopyTo(dst.Unblocked);
            return ref dst;
        }

        [MethodImpl(Inline)]
        public Matrix256<N,U> Convert<U>()
            where U : unmanaged
               => new Matrix256<N,U>(SpanBlocks.force<T,U>(data));

        [MethodImpl(Inline)]
        public Matrix256<N,U> As<U>()
            where U : unmanaged
                => new Matrix256<N,U>(data.As<U>());

        /// <summary>
        /// Creates a copy of the matrix
        /// </summary>
        [MethodImpl(Inline)]
        public Matrix256<N,T> Replicate()
            => new Matrix256<N,T>(data.Replicate());

        public override bool Equals(object other)
            => throw new NotSupportedException();

        public override int GetHashCode()
            => throw new NotSupportedException();

        [MethodImpl(Inline)]
        public static implicit operator Matrix256<N,T>(SpanBlock256<T> src)
            => new Matrix256<N,T>(src);

        [MethodImpl(Inline)]
        public static implicit operator Matrix256<N,T>(Matrix256<N,N,T> src)
            => new Matrix256<N,T>(src);

        [MethodImpl(Inline)]
        public static implicit operator Matrix256<N,N,T>(Matrix256<N,T> src)
            => src.ToRectangular();

        [MethodImpl(Inline)]
        public static implicit operator NatSpan<N,T>(Matrix256<N,T> src)
            => src.Natural;

        [MethodImpl(Inline)]
        public static implicit operator ReadOnlySpan<T>(Matrix256<N,T> src)
            => src.Unsized;

        [MethodImpl(Inline)]
        public static implicit operator SpanBlock256<T>(Matrix256<N,T> src)
            => src.Unsized;

        [MethodImpl(Inline)]
        public static bool operator == (Matrix256<N,T> lhs, in Matrix256<N,T> rhs)
            => lhs.Equals(rhs);

        [MethodImpl(Inline)]
        public static bool operator != (Matrix256<N,T> lhs, in Matrix256<N,T> rhs)
            => !lhs.Equals(rhs);
    }
}