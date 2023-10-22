//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

public readonly struct EnumFormat<E>
    where E : unmanaged, Enum
{
    readonly E Value;

    public readonly EnumFormatMode Mode;

    readonly Func<E,string> F;

    [MethodImpl(Inline)]
    public EnumFormat(E src, EnumFormatMode mode = EnumFormatMode.Expr)
    {
        Value = src;
        Mode = mode;
        F = null;
    }

    [MethodImpl(Inline)]
    public EnumFormat(E src, Func<E,string> f)
    {
        Value = src;
        Mode = EnumFormatMode.Custom;
        F = f;
    }

    public string Format()
    {
        if(F != null)
            return F(Value);

        if(Mode.Test(EnumFormatMode.EmptyZero))
            if(bw64(Value) == 0)
                return EmptyString;

        return EnumRender<E>.Service.Format(Value,Mode);
    }

    public override string ToString()
        => Format();

    [MethodImpl(Inline)]
    public static implicit operator EnumFormat<E>(E src)
        => new EnumFormat<E>(src);

    [MethodImpl(Inline)]
    public static implicit operator EnumFormat<E>((E value, Func<E,string> f) src)
        => new (src.value, src.f);

    [MethodImpl(Inline)]
    public static implicit operator EnumFormat<E>((E src, EnumFormatMode mode) x)
        => new (x.src,x.mode);

    [MethodImpl(Inline)]
    public static implicit operator E(EnumFormat<E> src)
        => src.Value;

    [MethodImpl(Inline)]
    public static explicit operator byte(EnumFormat<E> src)
        => bw8(src.Value);

    [MethodImpl(Inline)]
    public static explicit operator ushort(EnumFormat<E> src)
        => bw16(src.Value);

    [MethodImpl(Inline)]
    public static explicit operator uint(EnumFormat<E> src)
        => bw32(src.Value);

    [MethodImpl(Inline)]
    public static explicit operator ulong(EnumFormat<E> src)
        => bw64(src.Value);
}
