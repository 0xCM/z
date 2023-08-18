//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static Numbers;

using T = num3;
using D = System.Byte;
using N = N3;

[DataWidth(Width), ApiComplete]
public readonly struct num3 : INumber<T>
{
    public readonly D Value;

    [MethodImpl(Inline)]
    public num3(D src)
        => Value = crop(src);

    [MethodImpl(Inline)]
    num3(uint src)
        => Value = (byte)src;

    public const byte Width = 3;

    public const D MaxValue = Limit.Max3u;

    public const D Mod = (D)MaxValue + 1;

    public static T Zero => default;

    public static T One => cover(1);

    public static T Min => cover(0);

    public static T Max => cover(MaxValue);

    public static N N => default;

    [MethodImpl(Inline)]
    public static D crop(D src)
        => (D)(MaxValue & src);

    [MethodImpl(Inline)]
    public static T create(ulong src)
        => new T((D)src);

    [MethodImpl(Inline)]
    static T cover(D src)
        => @as<D,T>(src);

    [MethodImpl(Inline)]
    public static T force<A>(A src)
        where A : unmanaged
            => T.crop(bw8(src));

    [MethodImpl(Inline), Op]
    public static bit test(T src, byte pos)
        => bit.test(src.Value, pos);

    [MethodImpl(Inline), Op]
    public static T set(T src, byte pos, bit state)
        => math.lt(pos, Width) ? cover(bit.set(src.Value, pos, state)) : src;

    [MethodImpl(Inline), Op]
    public static T negate(T src)
        => create(math.negate(src.Value));

    [MethodImpl(Inline)]
    public static bit eq(T a, T b)
        => a.Value == b.Value;

    [MethodImpl(Inline)]
    public static bit ne(T a, T b)
        => a.Value != b.Value;

    [MethodImpl(Inline)]
    public static bit gt(T a, T b)
        => a.Value > b.Value;

    [MethodImpl(Inline)]
    public static bit ge(T a, T b)
        => a.Value >= b.Value;

    [MethodImpl(Inline)]
    public static bit lt(T a, T b)
        => a.Value < b.Value;

    [MethodImpl(Inline)]
    public static bit le(T a, T b)
        => a.Value <= b.Value;

    [MethodImpl(Inline)]
    public static T invert(T src)
        => cover((D)(math.and(math.not(src.Value), MaxValue)));

    [MethodImpl(Inline), Op]
    public static T or(T a, T b)
        => cover((D)(a.Value | b.Value));

    [MethodImpl(Inline), Op]
    public static T and(T a, T b)
        => cover((D)(a.Value & b.Value));

    [MethodImpl(Inline), Op]
    public static T xor(T a, T b)
        => cover((D)(a.Value ^ b.Value));

    [MethodImpl(Inline), Op]
    public static T srl(T src, byte count)
        => cover((D)(src.Value >> count));

    [MethodImpl(Inline), Op]
    public static T sll(T src, byte count)
        => cover((D)(src.Value << count));

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
        return cover(math.gteq(c, Mod) ? math.sub(c, Mod) : c);
    }

    [MethodImpl(Inline), Op]
    public static T sub(T a, T b)
    {
        var c = math.sub((int)a.Value, (int)b.Value);
        return cover(c < 0 ? math.add((D)c, Mod) : (D)c);
    }

    [MethodImpl(Inline), Op]
    public static T mul(T a, T b)
        => reduce(math.mul(a.Value, b.Value));

    [MethodImpl(Inline), Op]
    public static T div(T a, T b)
        => cover(math.div(a.Value, b.Value));

    [MethodImpl(Inline)]
    public static T mod(T a, T b)
        => cover(math.mod(a.Value, b.Value));

    [MethodImpl(Inline)]
    public static string bitstring(T src)
        => BitRender.format(N, src.Value);

    [Parser]
    public static bool parse(string src, out T dst)
    {
        var outcome = byte.TryParse(src, out D x);
        dst = new T((D)(x & MaxValue));
        return outcome;
    }

    [Parser]
    public static bool parse(ReadOnlySpan<char> src, out T dst)
    {
        var result = byte.TryParse(src, out D x);
        dst = new T((D)(x & MaxValue));
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

    [MethodImpl(Inline)]
    public S Force<S>()
        where S : unmanaged
            => @as<T,S>(this);

    [MethodImpl(Inline)]
    public string Format()
        => Value.ToString();

    public string Bitstring()
        => bitstring(this);

    public override string ToString()
        => Format();

    [MethodImpl(Inline)]
    public int CompareTo(T src)
        => Value.CompareTo(src.Value);

    public override int GetHashCode()
        => (int)Value;

    public override bool Equals(object src)
        => src is T t && Equals(t);

    [MethodImpl(Inline)]
    public static implicit operator T(D src)
        => new T(src);

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
        => create((byte)src);

    [MethodImpl(Inline)]
    public static explicit operator T(uint src)
        => create((byte)src);

    [MethodImpl(Inline)]
    public static explicit operator T(ulong src)
        => create((byte)src);

    [MethodImpl(Inline)]
    public static T operator + (T x, T y)
        => add(x,y);

    [MethodImpl(Inline)]
    public static T operator - (T x, T y)
        => sub(x,y);

    [MethodImpl(Inline)]
    public static T operator * (T x, T y)
        => mul(x,y);

    [MethodImpl(Inline)]
    public static T operator / (T x, T y)
        => div(x,y);

    [MethodImpl(Inline)]
    public static T operator % (T x, T y)
        => mod(x,y);

    [MethodImpl(Inline)]
    public static T operator &(T x, T y)
        => and(x,y);

    [MethodImpl(Inline)]
    public static T operator |(T x, T y)
        => or(x,y);

    [MethodImpl(Inline)]
    public static T operator ^(T a, T b)
        => xor(a,b);

    [MethodImpl(Inline)]
    public static T operator >>(T x, int count)
        => srl(x, (byte)count);

    [MethodImpl(Inline)]
    public static T operator <<(T x, int count)
        => sll(x, (byte)count);

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
        => a.Value == b.Value;

    [MethodImpl(Inline)]
    public static bit operator !=(T a, T b)
        => a.Value != b.Value;

    [MethodImpl(Inline)]
    public static bit operator < (T a, T b)
        => a.Value < b.Value;

    [MethodImpl(Inline)]
    public static bit operator <= (T a, T b)
        => a.Value <= b.Value;

    [MethodImpl(Inline)]
    public static bit operator > (T a, T b)
        => a.Value > b.Value;

    [MethodImpl(Inline)]
    public static bit operator >= (T a, T b)
        => a.Value >= b.Value;

    [MethodImpl(Inline)]
    public static explicit operator OctalDigitSym(num3 src)
        => (OctalDigitSym)Digital.@char((OctalDigitValue)src.Value);
}
