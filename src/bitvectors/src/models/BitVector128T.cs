//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static vcpu;

using api = BitVectors;

/// <summary>
/// Defines a natural bitvector over an intrinsic vector
/// </summary>
/// <typeparam name="T">The cell type</typeparam>
/// <typeparam name="N">The bit-width type</typeparam>
[StructLayout(LayoutKind.Sequential, Size = 16)]
public struct BitVector128<T>
    where T : unmanaged
{
    Vector128<T> Data;

    /// <summary>
    /// Initializes a bitvector with the lo N bits of a scalar source
    /// </summary>
    /// <param name="data">The scalar source value</param>
    [MethodImpl(Inline)]
    public BitVector128(Vector128<T> data)
        => Data = data;

    public Vector128<T> State
    {
        [MethodImpl(Inline)]
        get => Data;
    }

    [MethodImpl(Inline)]
    public T Cell(byte index)
        => api.cell(this,index);

    /// <summary>
    /// The bitvector's natural width
    /// </summary>
    public int Width
    {
        [MethodImpl(Inline)]
        get => 128;
    }

    /// <summary>
    /// The bitvector's lower 64 bits
    /// </summary>
    public BitVector64 Lo
    {
        [MethodImpl(Inline)]
        get => vcell(v64u(Data),0);
    }

    /// <summary>
    /// The bitvector's upper 64 bits
    /// </summary>
    public BitVector64 Hi
    {
        [MethodImpl(Inline)]
        get => vcell(v64u(Data),1);
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

    public BitVector128<T> Clear()
    {
        Data = default;
        return this;
    }

    [MethodImpl(Inline)]
    public bit Test(byte index)
        => api.testbit(this,index);

    [MethodImpl(Inline)]
    public BitVector128<T> Enable(byte index)
    {
        Data = api.enable(this,index);
        return this;
    }

    [MethodImpl(Inline)]
    public BitVector128<T> Disable(byte index)
    {
        Data = api.disable(this, index);
        return this;
    }

    [MethodImpl(Inline)]
    public BitVector128<T> Set(byte index, bit state)
    {
        Data = api.setbit(this,index,state);
        return this;
    }

    [MethodImpl(Inline)]
    public void Store(Span<T> dst)
        => api.store(this, dst);

    [MethodImpl(Inline)]
    public void Store(Span<byte> dst)
        => api.store(this, dst);

    [MethodImpl(Inline)]
    public bit TestC()
        => api.testc(this);

    [MethodImpl(Inline)]
    public bit TestC(BitVector128<T> mask)
        => api.testc(this, mask);

    [MethodImpl(Inline)]
    public BitVector128<T> RotL(byte count)
        =>  api.rotl(this, count);

    [MethodImpl(Inline)]
    public BitVector128<T> RotR(byte count)
        =>  api.rotr(this, count);

    [MethodImpl(Inline)]
    public readonly bool Equals(BitVector128<T> y)
        => api.equals(this,y);

    public readonly override bool Equals(object obj)
        => obj is BitVector128<T> x && Equals(x);

    public readonly override int GetHashCode()
        => Data.GetHashCode();

    public override string ToString()
        => Format();

    public string Format()
        => api.bitstring(this);

    [MethodImpl(Inline)]
    public BitVector128<U> As<U>()
        where U : unmanaged
            => Data.As<T,U>();

    [MethodImpl(Inline)]
    public static implicit operator BitVector128<T>(Vector128<T> src)
        => new BitVector128<T>(src);

    [MethodImpl(Inline)]
    public static implicit operator Vector128<T>(BitVector128<T> src)
        => src.Data;

    /// <summary>
    /// Computes the bitwise AND between the operands
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline)]
    public static BitVector128<T> operator &(BitVector128<T> x, BitVector128<T> y)
        => api.and(x,y);

    /// <summary>
    /// Computes the bitwise AND between the operands
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline)]
    public static BitVector128<T> operator |(BitVector128<T> x, BitVector128<T> y)
        => api.or(x,y);

    /// <summary>
    /// Computes the bitwise XOR between the operands
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline)]
    public static BitVector128<T> operator ^(BitVector128<T> x, BitVector128<T> y)
        => api.xor(x,y);

    /// <summary>
    /// Computes the scalar product of the operands
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline)]
    public static bit operator *(BitVector128<T> x, BitVector128<T> y)
        => api.dot(x,y);

    /// <summary>
    /// Computes the 128-bit sum of the operands
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline)]
    public static BitVector128<T> operator +(BitVector128<T> x, BitVector128<T> y)
        => api.add(x,y);

    /// <summary>
    /// Computes the bitwise complement of the operand
    /// </summary>
    /// <param name="x">The source operand</param>
    [MethodImpl(Inline)]
    public static BitVector128<T> operator ~(BitVector128<T> src)
        => api.not(src);

    /// <summary>
    /// Computes the two's complement negation of the operand
    /// </summary>
    /// <param name="x">The source operand</param>
    [MethodImpl(Inline)]
    public static BitVector128<T> operator -(BitVector128<T> src)
        => api.negate(src);

    /// <summary>
    /// Shifts the source bits leftwards
    /// </summary>
    /// <param name="x">The source operand</param>
    [MethodImpl(Inline)]
    public static BitVector128<T> operator <<(BitVector128<T> x, int count)
        => api.sll(x,(byte)count);

    /// <summary>
    /// Shifts the source bits rightwards
    /// </summary>
    /// <param name="x">The source operand</param>
    [MethodImpl(Inline)]
    public static BitVector128<T> operator >>(BitVector128<T> x, int count)
        => api.srl(x,(byte)count);

    /// <summary>
    /// Returns true if the source vector is nonzero, false otherwise
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline)]
    public static bool operator true(BitVector128<T> src)
        => src.NonEmpty;

    /// <summary>
    /// Returns false if the source vector is the zero vector, false otherwise
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline)]
    public static bool operator false(BitVector128<T> src)
        => src.Empty;

    /// <summary>
    /// Determines whether operand content is identical
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline)]
    public static bit operator ==(BitVector128<T> x, BitVector128<T> y)
        => api.equals(x,y);

    /// <summary>
    /// Determines whether operand content is non-identical
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline)]
    public static bit operator !=(BitVector128<T> x, BitVector128<T> y)
        => !api.equals(x,y);

    public static Vector128<T> Ones
    {
        [MethodImpl(Inline)]
        get => vcpu.vones<T>(w128);
    }

    public static BitVector128<T> Zero => default;
}
