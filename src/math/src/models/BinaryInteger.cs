//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System;
using System.Globalization;
using System.Numerics;

public readonly struct BinaryInteger<T> : IBinaryInteger<T>
    where T : unmanaged, IBinaryInteger<T>
{
    readonly T Value;

    public BinaryInteger(T value)
    {
        Value = value;
    }

    static T INumberBase<T>.One
        => sys.one<T>();

    static int INumberBase<T>.Radix 
        => 10;

    static T INumberBase<T>.Zero
         => sys.zero<T>();

    static T IAdditiveIdentity<T, T>.AdditiveIdentity
        => sys.zero<T>();

    static T IMultiplicativeIdentity<T, T>.MultiplicativeIdentity
        => sys.one<T>();

    static T INumberBase<T>.Abs(T value)
        => gmath.abs(value);

    static bool INumberBase<T>.IsCanonical(T value)
        => true;

    static bool INumberBase<T>.IsComplexNumber(T value)
        => false;

    static bool INumberBase<T>.IsEvenInteger(T value)
        => gmath.even(value);

    static bool INumberBase<T>.IsFinite(T value)
        => true;

    static bool INumberBase<T>.IsImaginaryNumber(T value)
        => false;

    static bool INumberBase<T>.IsInfinity(T value)
        => false;

    static bool INumberBase<T>.IsInteger(T value)
        => true;

    static bool INumberBase<T>.IsNaN(T value)
        => false;

    static bool INumberBase<T>.IsNegative(T value)
        => gmath.negative(value);

    static bool INumberBase<T>.IsNegativeInfinity(T value)
        => false;

    static bool INumberBase<T>.IsNormal(T value)
        => true;

    static bool INumberBase<T>.IsOddInteger(T value)
        => gmath.odd(value);

    static bool INumberBase<T>.IsPositive(T value)
        => gmath.positive(value);

    static bool INumberBase<T>.IsPositiveInfinity(T value)
        => false;

    static bool IBinaryNumber<T>.IsPow2(T value)
        => Pow2.test(sys.u64(value));

    static bool INumberBase<T>.IsRealNumber(T value)
        => true;

    static bool INumberBase<T>.IsSubnormal(T value)
        => false;

    static bool INumberBase<T>.IsZero(T value)
        => gmath.eq(value, sys.zero<T>());

    static T IBinaryNumber<T>.Log2(T value)
        => sys.generic<T>(Pow2.log(sys.u64(value)));

    static T INumberBase<T>.MaxMagnitude(T x, T y)
        => gmath.max(gmath.abs(x), gmath.abs(y));

    static T INumberBase<T>.MinMagnitude(T x, T y)
        => gmath.min(gmath.abs(x), gmath.abs(y));

    static T IBinaryInteger<T>.PopCount(T value)
        => sys.generic<T>(gbits.pop(value));

    int IComparable.CompareTo(object? obj)
        => obj is T t ? gmath.cmp(Value, t) : 0;

    int IComparable<T>.CompareTo(T other)
        => gmath.cmp(Value, other);

    bool IEquatable<T>.Equals(T other)
        => gmath.eq(Value, other);

    int IBinaryInteger<T>.GetByteCount()
        => (int)sys.size<T>();

    static bool IBinaryInteger<T>.TryReadLittleEndian(ReadOnlySpan<byte> source, bool isUnsigned, out T value)
    {
        var result = source.Length >= sys.size<T>();
        if(result)
        {
            value = sys.first(sys.recover<T>(source));
        }
        else
        {
            value = default;
        }
        return result;
    }

    bool IBinaryInteger<T>.TryWriteLittleEndian(Span<byte> destination, out int bytesWritten)
    {
        var result = destination.Length >= sys.size<T>();
        if(result)
        {
            sys.first(sys.recover<T>(destination)) = Value;
            bytesWritten = (int)sys.size<T>();
        }
        else
        {
            bytesWritten = 0;            
        }
        return result;
    }

    static T IUnaryPlusOperators<T, T>.operator +(T value)
        => value;

    static T IAdditionOperators<T, T, T>.operator +(T left, T right)
        => gmath.add(left,right);

    static T IUnaryNegationOperators<T, T>.operator -(T value)
        => gmath.negate(value);

    static T ISubtractionOperators<T, T, T>.operator -(T left, T right)
        => gmath.sub(left,right);

    static T IBitwiseOperators<T, T, T>.operator ~(T value)
        => gmath.not(value);

    static T IIncrementOperators<T>.operator ++(T value)
        => gmath.inc(value);

    static T IDecrementOperators<T>.operator --(T value)
        => gmath.dec(value);

    static T IMultiplyOperators<T, T, T>.operator *(T left, T right)
        => gmath.mul(left,right);

    static T IDivisionOperators<T, T, T>.operator /(T left, T right)
        => gmath.div(left,right);

    static T IModulusOperators<T, T, T>.operator %(T left, T right)
        => gmath.mod(left,right);

    static T IBitwiseOperators<T, T, T>.operator &(T left, T right)
        => gmath.and(left,right);

    static T IBitwiseOperators<T, T, T>.operator |(T left, T right)
        => gmath.or(left,right);

    static T IBitwiseOperators<T, T, T>.operator ^(T left, T right)
        => gmath.xor(left,right);

    static T IShiftOperators<T, int, T>.operator <<(T value, int shiftAmount)
        => gmath.sll(value, (byte)shiftAmount);

    static T IShiftOperators<T, int, T>.operator >>(T value, int shiftAmount)
        => gmath.srl(value, (byte)shiftAmount);

    static bool IEqualityOperators<T, T, bool>.operator ==(T left, T right)
        => gmath.eq(left,right);

    static bool IEqualityOperators<T, T, bool>.operator !=(T left, T right)
        => gmath.neq(left,right);

    static bool IComparisonOperators<T, T, bool>.operator <(T left, T right)
        => gmath.lt(left,right);

    static bool IComparisonOperators<T, T, bool>.operator >(T left, T right)
        => gmath.gt(left,right);

    static bool IComparisonOperators<T, T, bool>.operator <=(T left, T right)
        => gmath.lteq(left,right);

    static bool IComparisonOperators<T, T, bool>.operator >=(T left, T right)
        => gmath.gteq(left,right);

    static T IShiftOperators<T, int, T>.operator >>>(T value, int shiftAmount)
        => gmath.sra(value,(byte)shiftAmount);

    static T INumberBase<T>.MaxMagnitudeNumber(T x, T y)
    {
        throw new NotImplementedException();
    }

    static T INumberBase<T>.MinMagnitudeNumber(T x, T y)
    {
        throw new NotImplementedException();
    }

    static T INumberBase<T>.Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    static T INumberBase<T>.Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    static T ISpanParsable<T>.Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    static T IParsable<T>.Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    static T IBinaryInteger<T>.TrailingZeroCount(T value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<T>.TryConvertFromChecked<TOther>(TOther value, out T result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<T>.TryConvertFromSaturating<TOther>(TOther value, out T result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<T>.TryConvertFromTruncating<TOther>(TOther value, out T result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<T>.TryConvertToChecked<TOther>(T value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<T>.TryConvertToSaturating<TOther>(T value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<T>.TryConvertToTruncating<TOther>(T value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<T>.TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out T result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<T>.TryParse(string? s, NumberStyles style, IFormatProvider? provider, out T result)
    {
        throw new NotImplementedException();
    }

    static bool ISpanParsable<T>.TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out T result)
    {
        throw new NotImplementedException();
    }

    static bool IParsable<T>.TryParse(string? s, IFormatProvider? provider, out T result)
    {
        throw new NotImplementedException();
    }

    static bool IBinaryInteger<T>.TryReadBigEndian(ReadOnlySpan<byte> source, bool isUnsigned, out T value)
    {
        throw new NotImplementedException();
    }

    int IBinaryInteger<T>.GetShortestBitLength()
    {
        throw new NotImplementedException();
    }

    string IFormattable.ToString(string? format, IFormatProvider? formatProvider)
    {
        throw new NotImplementedException();
    }

    bool ISpanFormattable.TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    bool IBinaryInteger<T>.TryWriteBigEndian(Span<byte> destination, out int bytesWritten)
    {
        throw new NotImplementedException();
    }

}
