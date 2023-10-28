//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

/// <summary>
/// Represents a base-2 polynomial of degree at most N = 15. The represented polynomial is of the form
/// a_i * x^i + . . . a_1 * x^1 + a_0 * x^0 where  a_i = 0 | 1 and i = 0..N
/// </summary>
public readonly struct GfPoly16
{
    readonly ushort Data;

    /// <summary>
    /// The degree (N) of the polynomial
    /// </summary>
    public byte Degree {get;}

    public static GfPoly16 FromExponents(params byte[] exponents)
        => new GfPoly16(exponents);

    public static GfPoly16 FromScalar(ushort data)
        => new GfPoly16(data);

    [MethodImpl(Inline)]
    public GfPoly16(params byte[] exponents)
    {
        Data = Gf.Poly<ushort>(exponents);
        Degree = exponents.Length != 0 ? exponents[0] : (byte)0;
    }

    [MethodImpl(Inline)]
    public GfPoly16(ushort src)
    {
        Data = src;
        Degree = (byte)(15 - bits.nlz(src));
    }

    /// <summary>
    /// Returns a bit indicating whether the coefficient for x^i is 1 or 0
    /// </summary>
    public bit this[byte i]
    {
        [MethodImpl(Inline)]
        get => gbits.test(Data,i);
    }

    /// <summary>
    /// Returns the scalar representation of the polynomial
    /// </summary>
    public ushort Scalar
    {
        [MethodImpl(Inline)]
        get => Data;
    }


    /// <summary>
    /// Specifies whether the polynomial is the zero polynomial
    /// </summary>
    public bool Nonzero
    {
        [MethodImpl(Inline)]
        get => !gmath.nonz(Data);
    }

    /// <summary>
    /// Converts the polynomial to a bitvector
    /// </summary>
    [MethodImpl(Inline)]
    public BitVector16 ToBitVector()
        => Data;

    /// <summary>
    /// Converts the polynomial to a representation with natural degree
    /// </summary>
    [MethodImpl(Inline)]
    public GfPoly<N9,ushort> ToNatPoly()
        => new GfPoly<N9, ushort>(Data);

    /// <summary>
    /// Formats the polynomial
    /// </summary>
    public string Format()
        => ToNatPoly().Format();

    [MethodImpl(Inline)]
    public static implicit operator ushort(GfPoly16 src)
        => src.Data;

    [MethodImpl(Inline)]
    public static implicit operator BitVector16(GfPoly16 src)
        => src.ToBitVector();

    [MethodImpl(Inline)]
    public static implicit operator GfPoly<N9,ushort>(GfPoly16 src)
        => src.ToNatPoly();

    public static GfPoly16 Zero => default;

}
