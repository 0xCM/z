//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines a blocked primal matrix of natural dimensions
    /// </summary>
    /// <typeparam name="M">The row count type</typeparam>
    /// <typeparam name="N">The column count type</typeparam>
    /// <typeparam name="T">The primal type</typeparam>
    public readonly ref struct Matrix256<M,N,T>
        where M : unmanaged, ITypeNat
        where N : unmanaged, ITypeNat
        where T : unmanaged
    {
        readonly SpanBlock256<T> data;

        /// <summary>
        /// The number of matrix rows
        /// </summary>
        public static int Rows
            => (int)Typed.nat64u<M>();

        /// <summary>
        /// The number of matrix colums
        /// </summary>
        public static int Cols
            => (int)Typed.nat64u<N>();

        /// <summary>
        /// The total number of matrix cells
        /// </summary>
        public static int Capacity
            => (int)NatCalc.mul<M,N>();


        [MethodImpl(Inline)]
        public Matrix256(in SpanBlock256<T> src)
        {
            var count = src.CellCount;
            Require.invariant(Capacity >= src.CellCount, () => $"{nameof(Capacity)}:={Capacity} < {nameof(src.CellCount)}:={count}");
            data = src;
        }

        [MethodImpl(Inline)]
        internal Matrix256(in SpanBlock256<T> src, bool skipChecks)
            => data = src;

        [MethodImpl(Inline)]
        public ref T Cell(int r, int c)
            => ref data[Cols*r + c];

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
        public Block256<N,T> GetRow(int row)
        {
            if(row < 0 || row >= Rows)
                throw AppErrors.IndexOutOfRange(row, 0, Rows - 1);

            return RowVectors.blockload<N,T>(data.Slice(row * Cols, Cols));
        }

        [MethodImpl(Inline)]
        public ref Block256<N,T> GetRow(int row, ref Block256<N,T> dst)
        {
            if(row < 0 || row >= Rows)
                throw AppErrors.IndexOutOfRange(row, 0, Rows - 1);
             var src = data.Slice(row * Cols, Cols);
             src.CopyTo(dst.Unsized);
             return ref dst;
        }

        public ref Block256<M,T> GetCol(int col, ref Block256<M,T> dst)
        {
            if(col < 0 || col >= Cols)
                throw AppErrors.IndexOutOfRange(col, 0, Cols - 1);

            for(var row = 0; row < Rows; row++)
                dst[row] = data[row*Cols + col];
            return ref dst;
        }

        [MethodImpl(Inline)]
        public Block256<M,T> GetCol(int col)
        {
            var alloc = RowVectors.blockalloc<M,T>();
            return GetCol(col, ref alloc);
        }

        /// <summary>
        /// Replaces an index-identied column of data with the content of a column vector
        /// </summary>
        /// <param name="col">The column index</param>
        [MethodImpl(Inline)]
        public void SetCol(int col, Block256<M,T> src)
        {
            for(var row=0; row < Rows; row++)
                this[row,col] = src[row];
        }

        /// <summary>
        /// Interchages rows and columns
        /// </summary>
        public Matrix256<N,M,T> Transpose()
        {
            var dst = Matrix.blockalloc<N,M,T>();
            for(var row = 0; row < Rows; row++)
                dst.SetCol(row, GetRow(row));
            return dst;
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
        public TableSpan<M,N,T> Natural
        {
            [MethodImpl(Inline)]
            get => TableSpans.load<M,N,T>(data);
        }

        /// <summary>
        /// Applies a function to each cell and overwites the existing cell value with the result
        /// </summary>
        /// <param name="f">The function to apply</param>
        public Matrix256<M,N,T> Apply(Func<T,T> f)
        {
            for(var r = 0; r < Rows; r++)
            for(var c = 0; c < Cols; c++)
                this[r,c] = f(this[r,c]);
            return this;
        }

        public bool IsZero
        {
            get
            {
                for(var i = 0; i < data.CellCount; i++)
                    if(gmath.nonz(data[i]))
                        return false;
                return true;
            }
        }

        public bool NonEmpty
        {
            get => !IsZero;
        }

        public bool Equals(Matrix256<M,N,T> rhs)
        {
            for(var r = 0; r < (int)Rows; r ++)
            for(var c = 0; c < (int)Cols; c ++)
                if(!gmath.eq(this[r,c], rhs[r,c]))
                    return false;
            return true;
        }

        [MethodImpl(Inline)]
        public ref Matrix256<M,N,T> CopyTo(ref Matrix256<M,N,T> dst)
        {
            Unblocked.CopyTo(dst.Unblocked);
            return ref dst;
        }

        /// <summary>
        /// Converts the entries of the matrix to a specified type and
        /// populates a new matrix with the converted values
        /// </summary>
        /// <typeparam name="U">The conversion target type</typeparam>
        [MethodImpl(Inline)]
        public Matrix256<M,N,U> Convert<U>()
            where U : unmanaged
               => new Matrix256<M,N,U>(SpanBlocks.force<T,U>(data));

        /// <summary>
        /// Converts the entries of the matrix to a specified type and
        /// populates a new matrix with the converted values
        /// </summary>
        /// <typeparam name="U">The conversion target type</typeparam>
        [MethodImpl(Inline)]
        public ref Matrix256<M,N,U> Convert<U>(out Matrix256<M,N,U> dst)
            where U : unmanaged
        {
            dst = new Matrix256<M,N,U>(SpanBlocks.force<T,U>(data));
            return ref dst;
        }

        /// <summary>
        /// Reinterprets the primal type of the matrix
        /// </summary>
        /// <typeparam name="U">The target type</typeparam>
        [MethodImpl(Inline)]
        public Matrix256<M,N,U> As<U>()
            where U : unmanaged
               => new Matrix256<M,N,U>(data.As<U>());

        /// <summary>
        /// Reinterprets the primal type of the matrix
        /// </summary>
        /// <typeparam name="U">The target type</typeparam>
        [MethodImpl(Inline)]
        public ref Matrix256<M,N,U> As<U>(out Matrix256<M,N,U> dst)
            where U : unmanaged
        {
            dst = this.As<U>();
            return ref dst;
        }

        public override bool Equals(object other)
            => throw new NotSupportedException();

        public override int GetHashCode()
            => throw new NotSupportedException();

        public static implicit operator Matrix256<M,N,T>(in SpanBlock256<T> src)
            => new Matrix256<M,N,T>(src);

        public static implicit operator TableSpan<M,N,T>(in Matrix256<M,N,T> A)
            => A.Natural;

        public static implicit operator SpanBlock256<T>(in Matrix256<M,N,T> A)
            => A.Unsized;

        [MethodImpl(Inline)]
        public static bool operator == (in Matrix256<M,N,T> A, in Matrix256<M,N,T> B)
            => A.Equals(B);

        [MethodImpl(Inline)]
        public static bool operator != (in Matrix256<M,N,T> A, in Matrix256<M,N,T> B)
            => !A.Equals(B);
    }
}