//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using System.Numerics;
using T = num4;
using D = System.Byte;
using N = N4;

[DataWidth(Width), ApiComplete, StructLayout(LayoutKind.Sequential,Size=AlignedSize)]
public readonly struct num4 : INumber<T>,
    IShiftOperators<T,int,T>,
    IIncrementOperators<T>,
    IDecrementOperators<T>,
    IComparisonOperators<T,T,bit>
{
    public readonly D Value;

    public const byte Width = 4;

    public const int AlignedSize = 1;

    public const D MaxValue = NumericLimits.Max4u;

    public const D Mod = (D)MaxValue + 1;

    public static T Zero => default;

    public static T One => cover(1);

    public static T Min => cover(0);

    public static T Max => cover(MaxValue);

    public static N N => default;

    [MethodImpl(Inline)]
    public static D crop(D src)
        => (D)(MaxValue & src);

    [MethodImpl(Inline), Op]
    public static T number<S>(S src)
        where S : unmanaged
            => cover(crop(@as<S,D>(src)));

    [MethodImpl(Inline)]
    public static T cover(D src)
        => @as<D,T>(src);

    [MethodImpl(Inline), Op]
    public static bit test(T src, byte pos)
        => bit.test(src.Value, pos);

    [MethodImpl(Inline), Op]
    public static T set(T src, byte pos, bit state)
        => math.lt(pos, Width) ? cover(bit.set(src.Value, pos, state)) : src;

    [MethodImpl(Inline)]
    public static bit eq(T a, T b)
        => math.eq(a.Value, b.Value);

    [MethodImpl(Inline)]
    public static bit ne(T a, T b)
        => math.ne(a.Value, b.Value);

    [MethodImpl(Inline)]
    public static bit gt(T a, T b)
        => math.gt(a.Value, b.Value);

    [MethodImpl(Inline)]
    public static bit ge(T a, T b)
        => math.ge(a.Value, b.Value);

    [MethodImpl(Inline)]
    public static bit lt(T a, T b)
        => math.lt(a.Value, b.Value);

    [MethodImpl(Inline)]
    public static bit le(T a, T b)
        => math.le(a.Value, b.Value);

    [MethodImpl(Inline), Op]
    public static T negate(T src)
        => number(math.negate(src.Value));

    [MethodImpl(Inline)]
    public static T invert(T src)
        => number(math.not(src.Value));

    [MethodImpl(Inline), Op]
    public static T or(T a, T b)
        => number(math.or(a.Value, b.Value));

    [MethodImpl(Inline), Op]
    public static T and(T a, T b)
        => number(math.and(a.Value, b.Value));

    [MethodImpl(Inline), Op]
    public static T xor(T a, T b)
        => number(math.xor(a,b));

    [MethodImpl(Inline), Op]
    public static T srl(T src, byte count)
        => number(math.srl(src.Value, count));
    
    [MethodImpl(Inline), Op]
    public static T sll(T src, byte count)
        => number(math.sll(src.Value, count));

    [MethodImpl(Inline), Op]
    public static T inc(T src)
        => src.Value != MaxValue ? cover(math.inc(src.Value)) : Min;

    [MethodImpl(Inline), Op]
    public static T dec(T src)
        => src.Value != 0 ? cover(math.dec(src.Value)) : Max;

    [MethodImpl(Inline), Op]
    public static T reduce(T src)
        => cover(math.mod(src.Value, Mod));

    [MethodImpl(Inline), Op]
    public static T add(T a, T b)
    {
        var c = math.add(a.Value, b.Value);
        return cover(math.ge(c, Mod) ? math.sub(c, Mod) : c);
    }

    [MethodImpl(Inline), Op]
    public static T sub(T a, T b)
        => a + (-b);

    [MethodImpl(Inline), Op]
    public static T mul(T a, T b)
        => reduce(math.mul(a.Value, b.Value));

    [MethodImpl(Inline), Op]
    public static T div(T a, T b)
        => cover(math.div(a.Value, b.Value));

    [MethodImpl(Inline)]
    public static T mod(T a, T b)
        => cover(math.mod(a.Value, b.Value));

    [Parser]
    public static bool parse(ReadOnlySpan<char> src, out T dst)
    {
        var result = byte.TryParse(src, out D x);
        dst = number(x);
        return result;
    }

    [MethodImpl(Inline)]
    public bool Equals(T src)
        => Value == src.Value;

    byte INumber.PackedWidth
        => Width;

    ulong INumber.Value
        => Value;

    public bit IsZero
    {
        [MethodImpl(Inline)]
        get => Value == 0;
    }

    public bit IsNonZero
    {
        [MethodImpl(Inline)]
        get => Value != 0;
    }

    public bit IsMax
    {
        [MethodImpl(Inline)]
        get => Value == MaxValue;
    }

    public Hash32 Hash
    {
        [MethodImpl(Inline)]
        get => nhash(Value);
    }

    [MethodImpl(Inline)]
    public string Format()
        => Value.ToString();

    public string Bitstring()
        => BitRender.format(N, Value);

    public string Hex()
        => Value.FormatHex();
    public override string ToString()
        => Format();

    [MethodImpl(Inline)]
    public int CompareTo(T src)
        => Value.CompareTo(src.Value);

    public override int GetHashCode()
        => Hash;

    public override bool Equals(object src)
        => src is T t && Equals(t);

    [MethodImpl(Inline)]
    public static implicit operator T(D src)
        => number(src);

    [MethodImpl(Inline)]
    public static implicit operator D(T src)
        => src.Value;

    [MethodImpl(Inline)]
    public static explicit operator sbyte(T src)
        => (sbyte)src.Value;

    [MethodImpl(Inline)]
    public static implicit operator ushort(T src)
        => src.Value;

    [MethodImpl(Inline)]
    public static implicit operator uint(T src)
        => src.Value;

    [MethodImpl(Inline)]
    public static implicit operator ulong(T src)
        => src.Value;

    [MethodImpl(Inline)]
    public static explicit operator T(ushort src)
        => number((byte)src);

    [MethodImpl(Inline)]
    public static explicit operator T(uint src)
        => number((byte)src);

    [MethodImpl(Inline)]
    public static explicit operator T(ulong src)
        => number((byte)src);

    [MethodImpl(Inline)]
    public static explicit operator bit(T src)
        => (bit)(src.Value);

    [MethodImpl(Inline)]
    public static explicit operator num1(T src)
        => new (src.Value);

    [MethodImpl(Inline)]
    public static explicit operator num2(T src)
        => new (src.Value);

    [MethodImpl(Inline)]
    public static explicit operator num3(T src)
        => num3.number(src.Value);

    [MethodImpl(Inline)]
    public static implicit operator T(num1 src)
        => src.Value;

    [MethodImpl(Inline)]
    public static implicit operator T(num2 src)
        => src.Value;

    [MethodImpl(Inline)]
    public static implicit operator T(num3 src)
        => src.Value;

    [MethodImpl(Inline)]
    public static T operator + (T a, T b)
        => add(a, b);

    [MethodImpl(Inline)]
    public static T operator - (T a, T b)
        => sub(a, b);

    [MethodImpl(Inline)]
    public static T operator * (T a, T b)
        => mul(a, b);

    [MethodImpl(Inline)]
    public static T operator / (T a, T b)
        => div(a, b);

    [MethodImpl(Inline)]
    public static T operator % (T a, T b)
        => mod(a, b);

    [MethodImpl(Inline)]
    public static T operator &(T a, T b)
        => and(a, b);

    [MethodImpl(Inline)]
    public static T operator |(T a, T b)
        => or(a, b);

    [MethodImpl(Inline)]
    public static T operator ^(T a, T b)
        => xor(a, b);

    [MethodImpl(Inline)]
    public static T operator >>(T a, int count)
        => srl(a, (byte)count);

    [MethodImpl(Inline)]
    public static T operator <<(T a, int count)
        => sll(a, (byte)count);

    [MethodImpl(Inline)]
    public static T operator >>> (T a, int count)
        => srl(a, (byte)count);

    [MethodImpl(Inline)]
    public static T operator ~(T src)
        => invert(src);

    [MethodImpl(Inline)]
    public static T operator -(T src)
        => negate(src);

    [MethodImpl(Inline)]
    public static T operator ++(T x)
        => inc(x);

    [MethodImpl(Inline)]
    public static T operator --(T x)
        => dec(x);

    [MethodImpl(Inline)]
    public static bit operator ==(T a, T b)
        => eq(a,b);

    [MethodImpl(Inline)]
    public static bit operator !=(T a, T b)
        => ne(a,b);

    [MethodImpl(Inline)]
    public static bit operator < (T a, T b)
        => lt(a,b);

    [MethodImpl(Inline)]
    public static bit operator <= (T a, T b)
        => le(a,b);

    [MethodImpl(Inline)]
    public static bit operator > (T a, T b)
        => gt(a,b);

    [MethodImpl(Inline)]
    public static bit operator >= (T a, T b)
        => ge(a,b);

}
