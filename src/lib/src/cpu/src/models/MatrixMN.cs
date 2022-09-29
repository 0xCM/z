//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines a blocked primal matrix of natural dimensions
    /// </summary>
    /// <typeparam name="M">The row count type</typeparam>
    /// <typeparam name="N">The column count type</typeparam>
    /// <typeparam name="T">The primal type</typeparam>
    public struct Matrix<M,N,T>
        where M : unmanaged, ITypeNat
        where N : unmanaged, ITypeNat
        where T : unmanaged
    {
        T[] data;

        /// <summary>
        /// The number of rows in the structure
        /// </summary>
        public static int Rows => (int)nat64u<M>();

        /// <summary>
        /// The number of columns in the structure
        /// </summary>
        public static int Cols => (int)nat64u<N>();

        /// <summary>
        /// The total number of allocated elements
        /// </summary>
        public static int Cells => (int)NatCalc.mul<M,N>();

        [MethodImpl(Inline)]
        public static bool operator == (Matrix<M,N,T> lhs, Matrix<M,N,T> rhs)
            => lhs.Equals(rhs);

        [MethodImpl(Inline)]
        public static bool operator != (Matrix<M,N,T> lhs, Matrix<M,N,T> rhs)
            => !lhs.Equals(rhs);

        [MethodImpl(Inline)]
        public Matrix(T[] src)
        {
            Require.invariant(src.Length >= Cells, () => $"{src.Length} != {Cells}");
            data = src;
        }

        /// <summary>
        /// The number of rows in the matrix
        /// </summary>
        public readonly int RowCount
        {
            [MethodImpl(Inline)]
            get => Rows;
        }

        /// <summary>
        /// The number of columns in the matrix
        /// </summary>
        public readonly int ColCount
        {
            [MethodImpl(Inline)]
            get => Cols;
        }

        /// <summary>
        /// Provides access to the underlying data as a linear unblocked span
        /// </summary>
        public T[] Data
        {
            [MethodImpl(Inline)]
            get => data;
        }

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

        /// <summary>
        /// Returns a row data copy
        /// </summary>
        public Block256<N,T> this[int r]
        {
            [MethodImpl(Inline)]
            get => GetRow(r);
        }

        [MethodImpl(Inline)]
        public Block256<N,T> GetRow(int row)
        {
            if(row < 0 || row >= Rows)
                throw AppErrors.IndexOutOfRange(row, 0, Rows - 1);

            return RowVectors.blockload<N,T>(data.AsSpan().Slice(row * Cols, Cols));
        }

        [MethodImpl(Inline)]
        public ref Block256<N,T> GetRow(int row, ref Block256<N,T> dst)
        {
            if(row < 0 || row >= Rows)
                throw AppErrors.IndexOutOfRange(row, 0, Rows - 1);
             var src = data.AsSpan().Slice(row * Cols, Cols);
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
        public Matrix<N,M,T> Transpose()
        {
            var dst = Matrix.alloc<N,M,T>();
            for(var row = 0; row < Rows; row++)
                dst.SetCol(row, GetRow(row));
            return dst;
        }

        /// <summary>
        /// Applies a function to each cell and overwites the existing cell value with the result
        /// </summary>
        /// <param name="f">The function to apply</param>
        public Matrix<M,N,T> Apply(Func<T,T> f)
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
                for(var i = 0; i < data.Length; i++)
                    if(gmath.nonz(data[i]))
                        return false;
                return true;
            }
        }

        public bool Equals(Matrix<M,N,T> rhs)
        {
            for(var r = 0; r < (int)Rows; r ++)
            for(var c = 0; c < (int)Cols; c ++)
                if(!gmath.eq(this[r,c], rhs[r,c]))
                    return false;
            return true;
        }

        [MethodImpl(Inline)]
        public ref Matrix<M,N,T> CopyTo(ref Matrix<M,N,T> dst)
        {
            Data.CopyTo(dst.Data);
            return ref dst;
        }

        /// <summary>
        /// Converts the entries of the matrix to a specified type and
        /// populates a new matrix with the converted values
        /// </summary>
        /// <typeparam name="U">The conversion target type</typeparam>
        [MethodImpl(Inline)]
        public Matrix<M,N,U> Convert<U>()
            where U : unmanaged
               => new Matrix<M,N,U>(Numeric.force<T,U>(data));

        /// <summary>
        /// Converts the entries of the matrix to a specified type and
        /// populates a new matrix with the converted values
        /// </summary>
        /// <typeparam name="U">The conversion target type</typeparam>
        [MethodImpl(Inline)]
        public ref Matrix<M,N,U> Convert<U>(out Matrix<M,N,U> dst)
            where U : unmanaged
        {
            dst = new Matrix<M,N,U>(Numeric.force<T,U>(data));
            return ref dst;
        }

        public override bool Equals(object rhs)
            => rhs is Matrix<M,N,T> x && Equals(x);

        public override int GetHashCode()
            => data.GetHashCode();
    }
}