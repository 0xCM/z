//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    /// <summary>
    /// Defines an 8x8 matrix of bits
    /// </summary>
    [IdentityProvider(typeof(BitMatrixIdentityProvider))]
    public struct BitMatrix8
    {
        ulong Data;

        [MethodImpl(Inline)]
        public void Fill(byte src)
        {
            Data = cpu.broadcast(src,w64);
        }

        /// <summary>
        /// The matrix order
        /// </summary>
        public const uint N = 8;

        /// <summary>
        /// Allocates an 8x8 identity bitmatrix
        /// </summary>
        public static BitMatrix8 Identity => BitMatrix.identity(n8);

        /// <summary>
        /// Allocates an 8x8 zero bitmatrix
        /// </summary>
        public static BitMatrix8 Zero => new BitMatrix8(new byte[N]);

        /// <summary>
        /// Allocates an 8x8 1-filled bitmatrix
        /// </summary>
        public static BitMatrix8 Ones => new BitMatrix8(0xFFFFFFFFFFFFFFFF);

        [MethodImpl(Inline)]
        internal BitMatrix8(Span<byte> src)
            => Data = first64u(src);

        [MethodImpl(Inline)]
        internal BitMatrix8(ulong src)
            => Data = src;

        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => bytes(Data);
        }

        /// <summary>
        /// A reference to the first row of the matrix
        /// </summary>
        public unsafe ref byte Head
        {
            [MethodImpl(Inline)]
            get => ref seek(Bytes,0);
        }

        /// <summary>
        /// The square matrix order
        /// </summary>
        public readonly int Order
        {
            [MethodImpl(Inline)]
            get => (int)N;
        }

        /// <summary>
        /// Reads/manipulates the bit in a specified cell
        /// </summary>
        /// <param name="row">The row index</param>
        /// <param name="col">The column index</param>
        /// <param name="src">The source value</param>
        public bit this[int row, int col]
        {
            [MethodImpl(Inline)]
            get => bit.test(skip(in Head,row), (byte)col);

            [MethodImpl(Inline)]
            set => seek(Head, row) = bit.set(seek(Head, row), (byte)col, value);
        }

        /// <summary>
        /// Gets/Sets the data for a row
        /// </summary>
        /// <param name="index">The row index</param>
        public ref BitVector8 this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Unsafe.As<byte,BitVector8>(ref seek(Head, index));
        }

        [MethodImpl(Inline)]
        public BitVector8 Col(int index)
            => BitVectors.create(n8, bits.gather((ulong)this, (C0 << index)));

        const ulong C0 =
            (1ul << 64 - 1*8) | (1ul << 64 - 2*8) | (1ul << 64 - 3*8) | (1ul << 64 - 4*8) |
            (1ul << 64 - 5*8) | (1ul << 64 - 6*8) | (1ul << 64 - 7*8) | 1;

        public override string ToString()
            => this.Format();

        [MethodImpl(Inline)]
        public readonly bool Equals(BitMatrix8 src)
            => BitMatrix.same(this, src);

        [MethodImpl(Inline)]

        public override bool Equals(object obj)
            => throw new NotSupportedException();

        public override int GetHashCode()
            => throw new NotSupportedException();

        [MethodImpl(Inline)]
        public static implicit operator BitMatrix<byte>(BitMatrix8 src)
            => BitMatrix.load<byte>(core.bytes(src));

        [MethodImpl(Inline)]
        public static explicit operator ulong(BitMatrix8 src)
            => core.u64(src.Data);

        [MethodImpl(Inline)]
        public static explicit operator BitMatrix8(ulong src)
            => new BitMatrix8(src);

        [MethodImpl(Inline)]
        public static BitMatrix8 operator & (BitMatrix8 A, BitMatrix8 B)
            =>  BitMatrix.and(A,B);

        [MethodImpl(Inline)]
        public static BitMatrix8 operator | (BitMatrix8 A, BitMatrix8 B)
            => BitMatrix.or(A,B);

        [MethodImpl(Inline)]
        public static BitMatrix8 operator ^ (BitMatrix8 A, BitMatrix8 B)
            => BitMatrixA.xor(A,B);

        [MethodImpl(Inline)]
        public static BitMatrix8 operator ~ (BitMatrix8 src)
            => BitMatrix.not(src);

        [MethodImpl(Inline)]
        public static BitMatrix8 operator - (BitMatrix8 A, BitMatrix8 B)
            => BitMatrix.xornot(A,B);

        [MethodImpl(Inline)]
        public static BitMatrix8 operator * (BitMatrix8 A, BitMatrix8 B)
            => BitMatrix.mul(A,B);

        [MethodImpl(Inline)]
        public static BitVector8 operator * (BitMatrix8 A, BitVector8 x)
            => BitMatrix.mul(A,x);

        [MethodImpl(Inline)]
        public static bit operator ==(BitMatrix8 A, BitMatrix8 B)
            => BitMatrix.same(A,B);

        [MethodImpl(Inline)]
        public static bit operator !=(BitMatrix8 A, BitMatrix8 B)
            => !BitMatrix.same(A,B);
    }
}