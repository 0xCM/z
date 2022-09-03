// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    /// <summary>
    /// Defines a 64x64 matrix of bits
    /// </summary>
    [IdentityProvider(typeof(BitMatrixIdentityProvider))]
    public ref struct BitMatrix64
    {
        internal readonly Span<ulong> Data;

        /// <summary>
        /// The matrix order
        /// </summary>
        public const uint N = 64;

        [MethodImpl(Inline)]
        internal BitMatrix64(Span<ulong> src)
            => this.Data = src;

        [MethodImpl(Inline)]
        internal BitMatrix64(bit fill)
        {
            Data = new ulong[N];
            if(fill)
                Data.Fill(ulong.MaxValue);
        }

        /// <summary>
        /// Specifies the number of rows in the matrix
        /// </summary>
        public readonly int Order
        {
            [MethodImpl(Inline)]
            get => (int)N;
        }

        /// <summary>
        /// The underlying matrix presented as a bytespan
        /// </summary>
        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => Data.Bytes();
        }

        /// <summary>
        /// The underlying matrix data
        /// </summary>
        public Span<ulong> Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        /// <summary>
        /// A reference to the first row of the matrix
        /// </summary>
        public ref ulong Head
        {
            [MethodImpl(Inline)]
            get => ref first(Data);
        }

        /// <summary>
        /// Queries/manipulates a bit in an identified cell
        /// </summary>
        /// <param name="row">The row index</param>
        /// <param name="col">The column index</param>
        public bit this[int row, int col]
        {
            [MethodImpl(Inline)]
            get => bit.test(skip(Data, row), (byte)col);

            [MethodImpl(Inline)]
            set =>  seek(Data,row) = bit.set(skip(Data, row), (byte)col, value);
        }

        /// <summary>
        /// Gets or sets the data for a specified row
        /// </summary>
        /// <param name="row">The row index</param>
        public ref BitVector64 this[int row]
        {
            [MethodImpl(Inline)]
            get => ref Unsafe.As<ulong,BitVector64>(ref seek(Head, row));
        }

        [MethodImpl(Inline)]
        public readonly BitVector64 Column(int index)
        {
            var col = 0ul;
            for(byte r = 0; r<N; r++)
                col = bits.setif(skip(Data,r), (byte)index, col, r);
            return col;
        }

        /// <summary>
        /// Interchanges the i'th and j'th rows where  0 <= i,j < 64
        /// </summary>
        /// <param name="i">A row index</param>
        /// <param name="j">A row index</param>
        [MethodImpl(Inline)]
        public void RowSwap(int i, int j)
            => Data.Swap((uint)i,(uint)j);

        public BitMatrix64 Transpose()
        {
            var dst = Replicate();
            for(var i=0; i<N; i++)
                dst.Data[i] = Column(i);
            return dst;
        }

        [MethodImpl(Inline)]
        public readonly BitMatrix64 Replicate()
            => new BitMatrix64(Data.Replicate());

        [MethodImpl(Inline)]
        public bool Equals(BitMatrix64 rhs)
            => BitMatrix.same(this,rhs);

        public override bool Equals(object obj)
            => throw new NotSupportedException();

        public override int GetHashCode()
            => throw new NotSupportedException();

        public override string ToString()
            => throw new NotSupportedException();

        [MethodImpl(Inline)]
        public static implicit operator BitMatrix<ulong>(in BitMatrix64 src)
            => BitMatrix.load(src.Data);

        [MethodImpl(Inline)]
        public static BitMatrix64 operator & (BitMatrix64 A, BitMatrix64 B)
            => BitMatrix.and(A,B);

        [MethodImpl(Inline)]
        public static BitMatrix64 operator | (BitMatrix64 A, BitMatrix64 B)
            => BitMatrix.or(A,B);

        [MethodImpl(Inline)]
        public static BitMatrix64 operator ^ (BitMatrix64 A, BitMatrix64 B)
            => BitMatrixA.xor(A,B);

        [MethodImpl(Inline)]
        public static BitMatrix64 operator ~ (BitMatrix64 A)
            => BitMatrix.not(A);

        [MethodImpl(Inline)]
        public static BitMatrix64 operator - (BitMatrix64 A, BitMatrix64 B)
            => BitMatrix.xornot(A,B);

        [MethodImpl(Inline)]
        public static BitMatrix64 operator * (BitMatrix64 A, BitMatrix64 B)
            => BitMatrix.mul(A,B);

        [MethodImpl(Inline)]
        public static BitVector64 operator * (BitMatrix64 A, BitVector64 B)
            => BitMatrix.mul(A,B);

        [MethodImpl(Inline)]
        public static Bit32 operator ==(BitMatrix64 A, BitMatrix64 B)
            => BitMatrix.same(A,B);

        [MethodImpl(Inline)]
        public static Bit32 operator !=(BitMatrix64 A, BitMatrix64 B)
            => !BitMatrix.same(A,B);

        /// <summary>
        /// Defines the 64x64 identity bitmatrix
        /// </summary>
        public static BitMatrix64 Identity
            => BitMatrix.identity(n64);

        /// <summary>
        /// Defines the 64x64 zero bitmatrix
        /// </summary>
        public static BitMatrix64 Zero
            => new BitMatrix64(new ulong[N]);
    }
}