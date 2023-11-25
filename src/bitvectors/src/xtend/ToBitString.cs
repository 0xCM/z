//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class XBv
{
    /// <summary>
    /// Converts the vector to a bitstring
    /// </summary>
    [MethodImpl(Inline)]
    public static BitString ToBitString<T>(this BitVector128<T> src)
        where T : unmanaged
            => vgcpu.bitstring(src.State, src.Width);

    /// <summary>
    /// Creates the vector's bitstring representation
    /// </summary>
    /// <param name="src">The source bitvector</param>
    [MethodImpl(Inline)]
    public static BitString ToBitString(this BitVector4 src)
        => BitVectors.bitstring(src);

    /// <summary>
    /// Creates the vector's bitstring representation
    /// </summary>
    /// <param name="src">The source bitvector</param>
    [MethodImpl(Inline)]
    public static BitString ToBitString(this BitVector8 src)
        => BitVectors.bitstring(src);

    /// <summary>
    /// Creates the vector's bitstring representation
    /// </summary>
    /// <param name="src">The source bitvector</param>
    [MethodImpl(Inline)]
    public static BitString ToBitString(this BitVector16 src)
        => BitVectors.bitstring(src);

    /// <summary>
    /// Creates the vector's bitstring representation
    /// </summary>
    /// <param name="src">The source bitvector</param>
    [MethodImpl(Inline)]
    public static BitString ToBitString(this BitVector24 src)
            => BitVectors.bitstring(src);

    /// <summary>
    /// Creates the vector's bitstring representation
    /// </summary>
    /// <param name="src">The source bitvector</param>
    [MethodImpl(Inline)]
    public static BitString ToBitString(this BitVector32 src)
            => BitVectors.bitstring(src);

    /// <summary>
    /// Creates the vector's bitstring representation
    /// </summary>
    /// <param name="src">The source bitvector</param>
    [MethodImpl(Inline)]
    public static BitString ToBitString(this BitVector64 x)
        => BitVectors.bitstring(x);
}
