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
    /// Defines a primal square matrix of natural order
    /// </summary>
    /// <typeparam name="N">The order type</typeparam>
    /// <typeparam name="T">The primal type</typeparam>
    public struct Matrix<N,T>
        where N : unmanaged, ITypeNat
        where T : unmanaged
    {
        T[] data;

        /// <summary>
        /// The square matrix dimension
        /// </summary>
        public static int Order => (int)Typed.nat64u<N>();

        /// <summary>
        /// The total number of allocated elements
        /// </summary>
        public static int Cells => (int)NatCalc.mul<N,N>();

        [MethodImpl(Inline)]
        public static implicit operator Matrix<N,T>(Matrix<N,N,T> src)
            => new Matrix<N,T>(src.Data);

        [MethodImpl(Inline)]
        public static implicit operator Matrix<N,N,T>(Matrix<N,T> src)
            => new Matrix<N,N,T>(src.Data);

        [MethodImpl(Inline)]
        public static implicit operator Span<T>(Matrix<N,T> src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator Matrix<N,T>(T[] src)
            => new Matrix<N, T>(src);

        [MethodImpl(Inline)]
        public static bool operator == (Matrix<N,T> lhs, Matrix<N,T> rhs)
            => lhs.Equals(rhs);

        [MethodImpl(Inline)]
        public static bool operator != (Matrix<N,T> lhs, Matrix<N,T> rhs)
            => !lhs.Equals(rhs);

        [MethodImpl(Inline)]
        public Matrix(T[] src)
        {
            Require.invariant(src.Length >= Cells, () => $"{src.Length} != {Cells}");
            data = src;
        }

        [MethodImpl(Inline)]
        public ref T Cell(int r, int c)
            => ref data[Order*r + c];

        /// <summary>
        /// The data contained in the matrix
        /// </summary>
        public T[] Data
        {
            [MethodImpl(Inline)]
            get => data;
        }

        /// <summary>
        /// The data contained in the matrix
        /// </summary>
        /// <value></value>
        public Span<T> Span
        {
            [MethodImpl(Inline)]
            get => data;
        }

        /// <summary>
        /// The number of rows in the matrix
        /// </summary>
        public readonly int RowCount
        {
            [MethodImpl(Inline)]
            get => Order;
        }

        /// <summary>
        /// The number of columns in the matrix
        /// </summary>
        public readonly int ColCount
        {
            [MethodImpl(Inline)]
            get => Order;
        }

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
        public RowVector<N,T> this[int r]
        {
            [MethodImpl(Inline)]
            get => Row(r);
        }

        [MethodImpl(Inline)]
        public RowVector<N,T> Row(int row)
        {
            var alloc = RowVectors.alloc<N,T>();
            return GetRow(row, ref alloc);
        }

        /// <summary>
        /// Interchages rows and columns
        /// </summary>
        public Matrix<N,T> Transpose()
        {
            var dst = Matrix.alloc<N,T>();
            for(var i = 0; i < RowCount; i++)
                dst.SetRow(i,Col(i));
            return dst;
        }

        [MethodImpl(Inline)]
        void CheckRowIndex(int row)
        {
            if(row < 0 || row >= Order)
                throw AppErrors.IndexOutOfRange(row, 0, Order - 1);
        }

        [MethodImpl(Inline)]
        public void SetRow(int row, RowVector<N,T> src)
        {
            CheckRowIndex(row);
            var offset = row * Order;
            src.Storage.AsSpan().CopyTo(data, offset);
        }

        [MethodImpl(Inline)]
        public ref RowVector<N,T> GetRow(int row, ref RowVector<N,T> dst)
        {
             CheckRowIndex(row);
             var offset = row * Order;
             data.AsSpan().Slice(offset, Order).CopyTo(dst.Storage);
             return ref dst;
        }

        public ref RowVector<N,T> GetCol(int col, ref RowVector<N,T> dst)
        {
            if(col < 0 || col >= Order)
                throw AppErrors.IndexOutOfRange(col, 0, Order - 1);

            for(var row = 0; row < Order; row++)
                dst[row] = data[row*Order + col];
            return ref dst;
        }

        [MethodImpl(Inline)]
        public RowVector<N,T> Col(int col)
        {
            var alloc = RowVectors.alloc<N,T>();
            return GetCol(col, ref alloc);
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

        public bool Equals(Matrix<N,T> rhs)
        {
            for(var r = 0; r < (int)Order; r ++)
            for(var c = 0; c < (int)Order; c ++)
                if(!gmath.eq(this[r,c], rhs[r,c]))
                    return false;
            return true;
        }

        /// <summary>
        /// Returns the first cell value, if any, that satisfies a supplied predicate
        /// </summary>
        /// <param name="f">The predicate</param>
        /// <param name="pos">The cell position where the match was found</param>
        public Option<T> First(Func<T,bool> f, out (int i, int j) pos)
        {
            pos = (0,0);
            for(var r = 0; r < (int)Order; r ++)
            for(var c = 0; c < (int)Order; c ++)
            {
                if(f(this[r,c]))
                {
                    pos = (r,c);
                    return this[r,c];
                }
            }
            return default;
        }

        public Option<T> First(Func<T,bool> f)
        {
            for(var r = 0; r < (int)Order; r ++)
            for(var c = 0; c < (int)Order; c ++)
                if(f(this[r,c]))
                    return this[r,c];
            return default;
        }

        [MethodImpl(Inline)]
        public Matrix<N,N,T> ToRectangular()
            => new Matrix<N,N,T>(this.data);

        [MethodImpl(Inline)]
        public Matrix<N,U> Convert<U>()
            where U : unmanaged
               => new Matrix<N,U>(Numeric.force<T,U>(data));

        /// <summary>
        /// Creates a copy of the matrix
        /// </summary>
        [MethodImpl(Inline)]
        public Matrix<N,T> Replicate()
            => new Matrix<N,T>(data.Replicate());

        public override bool Equals(object rhs)
            => rhs is Matrix<N,T> x && Equals(x);

        public override int GetHashCode()
            => data.GetHashCode();
    }
}