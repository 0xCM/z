//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [IdentityProvider(typeof(BitMatrixIdentityProvider))]
    public struct BitMatrix4
    {
        ushort Data;

        /// <summary>
        /// The matrix order
        /// </summary>
        public const uint N = 4;

        /// <summary>
        /// Allocates a matrix, optionally assigning each element to the specified bit value
        /// </summary>
        [MethodImpl(Inline)]
        public static BitMatrix4 alloc(bool fill)
            => fill ? new BitMatrix4(ushort.MaxValue) : new BitMatrix4(ushort.MinValue);

        [MethodImpl(Inline)]
        public static BitMatrix4 From(ushort src)
            => new BitMatrix4(src);

        const byte M4 = 0b1111;

        [MethodImpl(Inline)]
        internal BitMatrix4(ushort src)
        {
            Data = src;
        }

        public int Order => (int)N;

        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get =>  bytes(Data);
        }

        /// <summary>
        /// Gets an index-identified row vector
        /// </summary>
        /// <param name="index">The row index</param>
        [MethodImpl(Inline)]
        BitVector4 GetRow(int index)
            => (byte)(M4 & (Data >> index*4));

        [MethodImpl(Inline)]
        void SetRow(int row, BitVector4 value)
        {
            ushort result = 0;
            for(var i=0; i<N; i++)
                result |= (ushort)(i == row ? value.State << 4*i : this[row]);
            Data = result;
        }

        public bit this[int row, int col]
        {
            [MethodImpl(Inline)]
            get => bit.test(Data, (byte)(row*4 + col));

            [MethodImpl(Inline)]
            set => Data = bit.set(Data, (byte)(row*4 + col), value);
        }

        public BitVector4 this[int row]
        {
            [MethodImpl(Inline)]
            get => GetRow(row);

            [MethodImpl(Inline)]
            set => SetRow(row, value);
        }

        [MethodImpl(Inline)]
        public readonly bool Equals(in BitMatrix4 B)
            => Data == B.Data;

        public override bool Equals(object obj)
            => throw new NotSupportedException();

        public override int GetHashCode()
            => throw new NotSupportedException();

        /// <summary>
        /// Allocates a 4x4 identity bitmatrix
        /// </summary>
        public static BitMatrix4 Identity
            => BitMatrix.identity(n4);

        public static BitMatrix4 Zero
            => new BitMatrix4(ushort.MinValue);

        public static BitMatrix4 Ones
            => new BitMatrix4(ushort.MaxValue);

        [MethodImpl(Inline)]
        public static explicit operator ushort(BitMatrix4 src)
            => src.Data;

        [MethodImpl(Inline)]
        public static explicit operator uint(BitMatrix4 src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator BitMatrix4(ushort src)
            => From(src);

        [MethodImpl(Inline)]
        public static BitMatrix4 operator & (in BitMatrix4 A, in BitMatrix4 B)
            => BitMatrix.and(A,B);

        [MethodImpl(Inline)]
        public static BitMatrix4 operator | (in BitMatrix4 A, in BitMatrix4 B)
            => BitMatrix.or(A,B);

        [MethodImpl(Inline)]
        public static BitMatrix4 operator ^ (in BitMatrix4 A, in BitMatrix4 B)
            => BitMatrix.xor(A,B);

        [MethodImpl(Inline)]
        public static BitMatrix4 operator ~ (in BitMatrix4 src)
            => BitMatrix.not(src);

        [MethodImpl(Inline)]
        public static BitMatrix4 operator * (in BitMatrix4 A, in BitMatrix4 B)
            => BitMatrix.mul(A,B);

        [MethodImpl(Inline)]
        public static BitVector4 operator * (in BitMatrix4 A, in BitVector4 x)
            => BitMatrix.mul(A,x);

        [MethodImpl(Inline)]
        public static bool operator ==(BitMatrix4 A, BitMatrix4 B)
            => BitMatrix.same(A,B);

        [MethodImpl(Inline)]
        public static bool operator !=(BitMatrix4 A, BitMatrix4 B)
            => !BitMatrix.same(A,B);
    }
}