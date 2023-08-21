//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

/// <summary>
/// Defines a signed 8-bit displacement
/// </summary>
public readonly record struct Disp8 : IDisplacement<Disp8,sbyte>
{
    /// <summary>
    /// The base displacement magnitude
    /// </summary>
    public readonly sbyte Value;

    [MethodImpl(Inline)]
    public Disp8(sbyte @base)
    {
        Value = @base;
    }

    public NativeSize Size
        => NativeSizeCode.W8;

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

    long IDisplacement.Value
        => Value;

    public Hash32 Hash
    {
        [MethodImpl(Inline)]
        get => Value;
    }

    sbyte IDisplacement<sbyte>.Value 
        => Value;

    public override int GetHashCode()
        => Hash;

    [MethodImpl(Inline)]
    public bool Equals(Disp8 src)
        => Value == src.Value;

    public string Format()
        => Disp.format(this);

    public override string ToString()
        => Format();

    [MethodImpl(Inline)]
    public static implicit operator Disp8(byte src)
        => new Disp8((sbyte)src);

    [MethodImpl(Inline)]
    public static implicit operator Disp8(sbyte src)
        => new Disp8(src);

    [MethodImpl(Inline)]
    public static implicit operator byte(Disp8 src)
        => (byte)src.Value;

    [MethodImpl(Inline)]
    public static explicit operator sbyte(Disp8 src)
        => src.Value;

    [MethodImpl(Inline)]
    public static implicit operator Disp(Disp8 src)
        => new Disp(src.Value, src.Size);
}
