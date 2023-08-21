//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;


public readonly struct SymVal : IEquatable<SymVal>, ISymVal<ulong>
{
    [Parser]
    public static Outcome parse(string src, out SymVal dst)
    {
        dst = default;
        var result = NumericParser.parse(src, out ulong x);
        if(result)
            dst = x;
        return result;
    }

    public ulong Value {get;}

    public NumericBaseKind Base {get;}

    [MethodImpl(Inline)]
    public SymVal(ulong value, NumericBaseKind @base = NumericBaseKind.Base10)
    {
        Value = value;
        Base = @base;
    }

    [MethodImpl(Inline)]
    public bool Equals(SymVal src)
        => Value.Equals(src.Value);

    [MethodImpl(Inline), Op]
    static string format(ulong src, Base2 @base, int? digits = null)
        => "<unsupported>";

    [MethodImpl(Inline), Op]
    static string format(ulong src, Base8 @base, int? digits = null)
        => Convert.ToString((long)src,8);

    [MethodImpl(Inline), Op]
    static string format(ulong src, Base10 @base, int? digits = null)
        => src.ToString();

    [MethodImpl(Inline), Op]
    static string format(ulong src, Base16 @base, int? digits = null)
        => src.FormatHex(false, false);

    [MethodImpl(Inline), Op]
    static string format(ulong src, Base2 @base, int? digits, bool specifier)
        => (specifier ? "0b" : EmptyString) + "<unimplemented>";

    [MethodImpl(Inline), Op]
    static string format(ulong src, Base8 @base, int? digits, bool specifier)
        => Convert.ToString((long)src,8);

    [MethodImpl(Inline), Op]
    static string format(ulong src, Base10 @base, int? digits, bool specifier)
        => src.ToString();

    [MethodImpl(Inline), Op]
    static string format(ulong src, Base16 @base, int? digits, bool specifier)
        => src.FormatHex(false, specifier, prespec: specifier);

    [MethodImpl(Inline), Op]
    static string format(ulong src, NumericBaseKind @base, int? digits, bool specifier)
        => @base switch{
            NumericBaseKind.Base2 => format(src, base2, digits, specifier),
            NumericBaseKind.Base8 => format(src, base8, digits, specifier),
            NumericBaseKind.Base16 => format(src, base16, digits, specifier),
            _ => format(src, base10, digits, specifier),
        };

    public string Format()
        => format(Value, Base, null, true);

    public override string ToString()
        => Format();

    public override int GetHashCode()
        => Value.GetHashCode();

    public override bool Equals(object src)
        => src is SymVal x && Equals(x);

    [MethodImpl(Inline)]
    public static implicit operator SymVal(ulong src)
        => new SymVal(src);

    [MethodImpl(Inline)]
    public static implicit operator SymVal(ushort src)
        => new SymVal(src);

    [MethodImpl(Inline)]
    public static implicit operator SymVal(uint src)
        => new SymVal(src);

    [MethodImpl(Inline)]
    public static implicit operator SymVal(byte src)
        => new SymVal(src);

    [MethodImpl(Inline)]
    public static implicit operator SymVal((ulong src, NumericBaseKind nbk) x)
        => new SymVal(x.src, x.nbk);

    [MethodImpl(Inline)]
    public static implicit operator SymVal(long src)
        => new SymVal((ulong)src);

    [MethodImpl(Inline)]
    public static implicit operator SymVal((long src, NumericBaseKind nbk) x)
        => new SymVal((ulong)x.src, x.nbk);

    [MethodImpl(Inline)]
    public static implicit operator ulong(SymVal src)
        => src.Value;

    [MethodImpl(Inline)]
    public static explicit operator byte(SymVal src)
        => (byte)src.Value;

    [MethodImpl(Inline)]
    public static explicit operator sbyte(SymVal src)
        => (sbyte)src.Value;

    [MethodImpl(Inline)]
    public static explicit operator ushort(SymVal src)
        => (ushort)src.Value;

    [MethodImpl(Inline)]
    public static explicit operator short(SymVal src)
        => (short)src.Value;

    [MethodImpl(Inline)]
    public static explicit operator uint(SymVal src)
        => (uint)src.Value;

    [MethodImpl(Inline)]
    public static explicit operator int(SymVal src)
        => (int)src.Value;

    [MethodImpl(Inline)]
    public static explicit operator long(SymVal src)
        => (long)src.Value;

    public static SymVal Zero => default;
}
