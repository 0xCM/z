//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = BitVectors;

    /// <summary>
    /// Defines a natural bitvector over an intrinsic vector
    /// </summary>
    /// <typeparam name="T">The cell type</typeparam>
    /// <typeparam name="N">The bit-width type</typeparam>
    [StructLayout(LayoutKind.Sequential, Size = 32)]
    public struct BitVector256<T>
        where T : unmanaged
    {
        Vector256<T> Data;

        /// <summary>
        /// Initializes a bitvector with the lo N bits of a scalar source
        /// </summary>
        /// <param name="data">The scalar source value</param>
        [MethodImpl(Inline)]
        public BitVector256(Vector256<T> data)
            => Data = data;

        public Vector256<T> State
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public Vector256<T> Clear()
        {
            Data = default;
            return this;
        }

        [MethodImpl(Inline)]
        public void Store(Span<T> dst)
            => api.store(this, dst);

        [MethodImpl(Inline)]
        public void Store(Span<byte> dst)
            => api.store(this, dst);

        [MethodImpl(Inline)]
        public T Cell(byte index)
            => api.cell(this,index);

        [MethodImpl(Inline)]
        public readonly bool Equals(BitVector256<T> src)
            => api.equals(this,src);

        public readonly override bool Equals(object src)
            => src is BitVector256<T> x && Equals(x);

        public readonly override int GetHashCode()
            => Data.GetHashCode();

        [MethodImpl(Inline)]
        public ulong Seg64(N0 n)
            => api.seg64(this,n);

        [MethodImpl(Inline)]
        public ulong Seg64(N1 n)
            => api.seg64(this,n);

        [MethodImpl(Inline)]
        public ulong Seg64(N2 n)
            => api.seg64(this,n);

        [MethodImpl(Inline)]
        public ulong Seg64(N3 n)
            => api.seg64(this,n);

        [MethodImpl(Inline)]
        public byte Seg8(byte pos)
            => api.seg8(this,pos);

        [MethodImpl(Inline)]
        public ushort Seg16(byte pos)
            => api.seg16(this,pos);

        [MethodImpl(Inline)]
        public uint Seg32(byte pos)
            => api.seg32(this,pos);

        [MethodImpl(Inline)]
        public ulong Seg64(byte pos)
            => api.seg64(this,pos);

        /// <summary>
        /// The bitvector's lower 64 bits
        /// </summary>
        public BitVector128<T> Lo
        {
            [MethodImpl(Inline)]
            get => vgcpu.vlo(Data);
        }

        /// <summary>
        /// The bitvector's upper 64 bits
        /// </summary>
        public BitVector128<T> Hi
        {
            [MethodImpl(Inline)]
            get => vgcpu.vhi(Data);
        }

        /// <summary>
        /// The bitvector's invariant width
        /// </summary>
        public int Width
        {
            [MethodImpl(Inline)]
            get => 256;
        }

        /// <summary>
        /// Specifies whether all bits are disabled
        /// </summary>
        public bit Empty
        {
            [MethodImpl(Inline)]
            get => api.equals(this, Zero);
        }

        /// <summary>
        /// Specifies whether at least one bit is enabled
        /// </summary>
        public bit NonEmpty
        {
            [MethodImpl(Inline)]
            get => !api.equals(this, Zero);
        }

        [MethodImpl(Inline)]
        public bit Test(byte pos)
            => api.testbit(this,pos);

        [MethodImpl(Inline)]
        public BitVector256<T> Enable(byte pos)
        {
            Data = api.enable(this, pos);
            return this;
        }

        [MethodImpl(Inline)]
        public BitVector256<T> Disable(byte pos)
        {
            Data = api.disable(this, pos);
            return this;
        }

        [MethodImpl(Inline)]
        public BitVector256<T> Set(byte pos, bit state)
        {
            Data = api.setbit(this, pos, state);
            return this;
        }

        [MethodImpl(Inline)]
        public bit TestC()
            => api.testc(this);

        [MethodImpl(Inline)]
        public bit TestC(BitVector256<T> mask)
            => api.testc(this, mask);

        [MethodImpl(Inline)]
        public BitVector256<T> RotL(byte count)
            =>  api.rotl(this, count);

        [MethodImpl(Inline)]
        public BitVector256<T> RotR(byte count)
            =>  api.rotr(this, count);

        public override string ToString()
            => Format();

        public string Format()
            => api.bitstring(this);

        [MethodImpl(Inline)]
        public BitVector256<U> As<U>()
            where U : unmanaged
                => Data.As<T,U>();

        [MethodImpl(Inline)]
        public static implicit operator BitVector256<T>(Vector256<T> src)
            => new BitVector256<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator Vector256<T>(BitVector256<T> src)
            => src.Data;

        /// <summary>
        /// Computes the bitwise AND between the operands
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static BitVector256<T> operator &(in BitVector256<T> x, in BitVector256<T> y)
            => api.and(x,y);

        /// <summary>
        /// Computes the bitwise AND between the operands
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static BitVector256<T> operator |(in BitVector256<T> x, in BitVector256<T> y)
            => api.or(x,y);

        /// <summary>
        /// Computes the bitwise XOR between the operands
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static BitVector256<T> operator ^(in BitVector256<T> x, in BitVector256<T> y)
            => api.xor(x,y);

        /// <summary>
        /// Computes the bitwise complement of the operand
        /// </summary>
        /// <param name="x">The source operand</param>
        [MethodImpl(Inline)]
        public static BitVector256<T> operator ~(in BitVector256<T> src)
            => api.not(src);

        /// <summary>
        /// Computes the two's complement negation of the operand
        /// </summary>
        /// <param name="x">The source operand</param>
        [MethodImpl(Inline)]
        public static BitVector256<T> operator -(in BitVector256<T> src)
            => api.negate(src);

        /// <summary>
        /// Shifts the source bits leftwards
        /// </summary>
        /// <param name="x">The source operand</param>
        [MethodImpl(Inline)]
        public static BitVector256<T> operator <<(in BitVector256<T> x, int count)
            => api.sll(x,(byte)count);

        /// <summary>
        /// Shifts the source bits rightwards
        /// </summary>
        /// <param name="x">The source operand</param>
        [MethodImpl(Inline)]
        public static BitVector256<T> operator >>(in BitVector256<T> x, int count)
            => api.srl(x,(byte)count);

        /// <summary>
        /// Computes the scalar product of the operands
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline)]
        public static bit operator *(in BitVector256<T> x, in BitVector256<T> y)
            => api.dot(x,y);

        /// <summary>
        /// Determines whether operand content is identical
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static bit operator ==(in BitVector256<T> x, in BitVector256<T> y)
            => api.equals(x,y);

        /// <summary>
        /// Determines whether operand content is non-identical
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static bit operator !=(in BitVector256<T> x, in BitVector256<T> y)
            => !api.equals(x,y);

        /// <summary>
        /// Returns true if the source vector is nonzero, false otherwise
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static bool operator true(in BitVector256<T> src)
            => src.NonEmpty;

        /// <summary>
        /// Returns false if the source vector is the zero vector, false otherwise
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static bool operator false(in BitVector256<T> src)
            => src.Empty;

        public static BitVector256<T> Zero => default;

        public static Vector256<T> Ones
        {
            [MethodImpl(Inline)]
            get => vgcpu.vones<T>(w256);
        }
    }
}