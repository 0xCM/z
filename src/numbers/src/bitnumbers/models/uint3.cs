//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static BitNumbers;

using T = uint3;
using W = W3;
using K = BitSeq3;
using D = System.Byte;
using N = N3;
using U = uint3;

/// <summary>
/// Represents a value in the range [<see cef='MinLiteral'/>, <see cref='MaxValue'/>]
/// </summary>
public struct uint3 : IBitNumber<T,W,K,D>
{
    [Parser]
    public static bool parse(string src, out U dst)
    {
        var result = BitParser.parse(src, Width, out byte b);
        dst = b;
        return result;
    }

    internal readonly D Value;

    [MethodImpl(Inline)]
    internal uint3(uint8b src)
        => Value = (byte)(src & MaxValue);

    [MethodImpl(Inline)]
    internal uint3(byte src)
        => Value = (byte)(T.MaxValue & src);

    [MethodImpl(Inline)]
    internal uint3(byte src, bool @unchecked)
        => Value = (byte)src;

    [MethodImpl(Inline)]
    internal uint3(K src)
        => Value = (byte)src;

    /// <summary>
    /// Queries an index-identified bit
    /// </summary>
    public bit this[byte pos]
    {
        [MethodImpl(Inline)]
        get => test(this, pos);
    }

    public K Kind
    {
        [MethodImpl(Inline)]
        get => (K) Value;
    }

    public D Content
    {
        [MethodImpl(Inline)]
        get => Value;
    }

    public bool IsZero
    {
        [MethodImpl(Inline)]
        get => Value == 0;
    }

    public bool IsNonZero
    {
        [MethodImpl(Inline)]
        get => Value != 0;
    }

    /// <summary>
    /// Specifies whether the current value is the maximum value
    /// </summary>
    public bool IsMax
    {
        [MethodImpl(Inline)]
        get => Value == MaxValue;
    }

    /// <summary>
    /// Specifies whether the current value is the minimum value
    /// </summary>
    public bool IsMin
    {
        [MethodImpl(Inline)]
        get => Value == MinLiteral;
    }

    public string Format()
            => format(this);

    public override string ToString()
        => Format();

    public string Format(BitFormat config)
        => format(this,config);

    [MethodImpl(Inline)]
    public bool Equals(T y)
        => eq(this,y);

    public override bool Equals(object y)
        => y is T x && Equals(x);

    byte IBits<byte>.Value
        => Value;

    byte IBits.Width
        => Width;
    public Hash32 Hash
    {
        [MethodImpl(Inline)]
        get => Value;
    }

    [MethodImpl(Inline)]
    public int CompareTo(T src)
        => Value.CompareTo(src.Value);

    public override int GetHashCode()
        => (int)Hash;

    [MethodImpl(Inline)]
    public static implicit operator uint5(T src)
        => new uint5(src.Value);

    [MethodImpl(Inline)]
    public static implicit operator uint6(T src)
        => new (src.Value);

    [MethodImpl(Inline)]
    public static implicit operator uint7(T src)
        => new (src.Value);

    [MethodImpl(Inline)]
    public static implicit operator uint8b(T src)
        => new (src.Value);

    [MethodImpl(Inline)]
    public static implicit operator T(uint8b src)
        => new (src);

    [MethodImpl(Inline)]
    public static implicit operator T(K src)
        => new (src);

    [MethodImpl(Inline)]
    public static implicit operator K(T src)
        => (K)src.Value;

    [MethodImpl(Inline)]
    public static explicit operator bit(T src)
        => new (src.Value & 1);

    [MethodImpl(Inline)]
    public static explicit operator T(bit src)
        => new((byte)src);

    /// <summary>
    /// Converts a 4-bit integer to an unsigned 8-bit integer
    /// </summary>
    /// <param name="src">The source value</param>
    [MethodImpl(Inline)]
    public static implicit operator byte(T src)
        => (byte)src.Value;

    /// <summary>
    /// Converts a 4-bit integer to an unsigned 16-bit integer
    /// </summary>
    /// <param name="src">The source value</param>
    [MethodImpl(Inline)]
    public static implicit operator ushort(T src)
        => (ushort)src.Value;

    /// <summary>
    /// Converts a 4-bit integer to an unsigned 32-bit integer
    /// </summary>
    /// <param name="src">The source value</param>
    [MethodImpl(Inline)]
    public static implicit operator uint(T src)
        => src.Value;

    /// <summary>
    /// Converts a 4-bit integer to an unsigned 64-bit integer
    /// </summary>
    /// <param name="src">The source value</param>
    [MethodImpl(Inline)]
    public static implicit operator ulong(T src)
        => src.Value;

    /// <summary>
    /// Converts a 4-bit integer to a signed 32-bit integer
    /// </summary>
    /// <param name="src">The source value</param>
    [MethodImpl(Inline)]
    public static implicit operator int(T src)
        => (int)src.Value;

    [MethodImpl(Inline)]
    public static implicit operator T(HexDigitValue src)
        => new ((byte)src, true);

    [MethodImpl(Inline)]
    public static implicit operator HexDigitValue(T src)
        => (HexDigitValue)src.Value;

    /// <summary>
    /// Creates a 4-bit integer from the least four bits of the source operand
    /// </summary>
    /// <param name="src">The source value</param>
    [MethodImpl(Inline)]
    public static explicit operator T(ulong src)
        => uint3(src);

    [MethodImpl(Inline)]
    public static T @bool(bool x)
        => x ? One : Zero;

    [MethodImpl(Inline)]
    public static bool operator true(T x)
        => x.Value != 0;

    [MethodImpl(Inline)]
    public static bool operator false(T x)
        => x.Value == 0;

    [MethodImpl(Inline)]
    public static T operator + (T x, T y)
        => add(x,y);

    [MethodImpl(Inline)]
    public static T operator - (T x, T y)
        => sub(x,y);

    [MethodImpl(Inline)]
    public static T operator * (T x, T y)
        => new(reduce3((byte)(x.Value * y.Value)));

    [MethodImpl(Inline)]
    public static T operator / (T x, T y)
        => wrap3((byte)(x.Value / y.Value));

    [MethodImpl(Inline)]
    public static T operator % (T x, T y)
        => wrap3((byte)(x.Value % y.Value));

    [MethodImpl(Inline)]
    public static T operator |(T x, T y)
        => wrap3((byte)(x.Value | y.Value));

    [MethodImpl(Inline)]
    public static T operator &(T x, T y)
        => wrap3((byte)(x.Value & y.Value));

    [MethodImpl(Inline)]
    public static T operator ^(T x, T y)
        => wrap3((byte)((byte)(x.Value & y.Value) & MaxValue));

    [MethodImpl(Inline)]
    public static T operator >>(T x, int y)
        => wrap3(x.Value >> y);

    [MethodImpl(Inline)]
    public static T operator <<(T x, int y)
        => wrap3(x.Value << y);

    [MethodImpl(Inline)]
    public static T operator ~(T src)
        => wrap3((byte)(~src.Value & MaxValue));

    [MethodImpl(Inline)]
    public static T operator ++(T x)
        => inc(x);

    [MethodImpl(Inline)]
    public static T operator --(T x)
        => dec(x);

    [MethodImpl(Inline)]
    public static bool operator ==(T x, T y)
        => eq(x,y);

    [MethodImpl(Inline)]
    public static bool operator !=(T x, T y)
        => !x.Equals(y);

    [MethodImpl(Inline)]
    public static T operator < (T x, T y)
        => @bool(x.Value < y.Value);

    [MethodImpl(Inline)]
    public static T operator <= (T x, T y)
        => @bool(x.Value <= y.Value);

    [MethodImpl(Inline)]
    public static T operator > (T x, T y)
        => @bool(x.Value > y.Value);

    [MethodImpl(Inline)]
    public static T operator >= (T x, T y)
        => @bool(x.Value >= y.Value);

    [MethodImpl(Inline)]
    public static implicit operator T(byte src)
        => new(src);

    [MethodImpl(Inline)]
    public static implicit operator Hex8(uint3 src)
        => src.Value;

    /// <summary>
    /// Specifies the inclusive lower bound of the <see cref='T'/> data type as a literal value
    /// </summary>
    public const byte MinLiteral = 0;

    /// <summary>
    /// Specifies the inclusive upper bound of the <see cref='T'/> data type as a literal value
    /// </summary>
    public const byte MaxValue = Pow2.T03m1;

    /// <summary>
    /// Specifies the count of unique values representable by a <see cref='T'/>
    /// </summary>
    public const byte Mod = (byte)MaxValue + 1;

    /// <summary>
    /// Specifies the represented data type bit-width
    /// </summary>
    public const byte Width = 4;

    public static W W => default;

    public static N N => default;

    /// <summary>
    /// Specifies the minimum <see cref='T'/> value
    /// </summary>
    public static T Min => default;

    /// <summary>
    /// Specifies the maximum <see cref='T'/> value
    /// </summary>
    public static T Max
    {
        [MethodImpl(Inline)]
        get => new T(MaxValue,true);
    }

    /// <summary>
    /// Specifies the <see cref='T'/> zero value
    /// </summary>
    public static T Zero
    {
        [MethodImpl(Inline)]
        get => new T(0,true);
    }

    /// <summary>
    /// Specifies the <see cref='T'/> one value
    /// </summary>
    public static T One
    {
        [MethodImpl(Inline)]
        get => new T(1,true);
    }
}
