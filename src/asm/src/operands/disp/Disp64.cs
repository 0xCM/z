//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

/// <summary>
/// Defines a signed 64-bit displacement
/// </summary>
public readonly struct Disp64 : IDisplacement<Disp64,long>
{
    public readonly long Value;

    [MethodImpl(Inline)]
    public Disp64(long value)
    {
        Value = value;
    }

    public NativeSize Size
        => NativeSizeCode.W64;

    public bool IsNonZero
    {
        [MethodImpl(Inline)]
        get => Value == 0;
    }

    public bool IsPositive
    {
        [MethodImpl(Inline)]
        get => Value > 0;
    }

    public bool IsNegative
    {
        [MethodImpl(Inline)]
        get => Value < 0;
    }

    [MethodImpl(Inline)]
    public bool Equals(Disp64 src)
        => Value == src.Value;

    public string Format()
        => Disp.format(this);

    public override string ToString()
        => Format();

    long IDisplacement<long>.Value
            => Value;

    long IDisplacement.Value
        => Value;

    [MethodImpl(Inline)]
    public static implicit operator ulong(Disp64 src)
        => (ulong)src.Value;

    [MethodImpl(Inline)]
    public static implicit operator long(Disp64 src)
        => src.Value;

    [MethodImpl(Inline)]
    public static implicit operator Disp(Disp64 src)
        => new (src.Value, src.Size);

    [MethodImpl(Inline)]
    public static implicit operator Disp64(ulong src)
        => new ((long)src);

    [MethodImpl(Inline)]
    public static implicit operator Disp64(long src)
        => new ((int)src);

    public static Disp64 Empty
    {
        [MethodImpl(Inline)]
        get => new (0);
    }
}
