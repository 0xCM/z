//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

/// <summary>
/// Represents a register index from the domain [0,31]
/// </summary>
public readonly record struct RegIndex : IComparable<RegIndex>
{
    [MethodImpl(Inline)]
    public static RegIndex from(byte value)
        => from((RegIndexCode)value);

    [MethodImpl(Inline)]
    public static RegIndex from(RegIndexCode code)
        => new (code);

    public readonly RegIndexCode Code;

    [MethodImpl(Inline)]
    public RegIndex(RegIndexCode kind)
        => Code = kind;

    public byte Encoded
    {
        [MethodImpl(Inline)]
        get => (byte) Code;
    }

    [MethodImpl(Inline)]
    public RegIndex Next()
        => (byte)Code < 31 ? (byte)((byte)Code + 1) : 0;

    [MethodImpl(Inline)]
    public RegIndex Prior()
        => (byte)Code > 0 ? (byte)((byte)Code - 1) : 31;

    [MethodImpl(Inline)]
    public int CompareTo(RegIndex src)
        => ((byte)Code).CompareTo((byte)src.Code);

    public string Format()
        => BitRender.format5(Encoded);

    public override string ToString()
        => Format();

    [MethodImpl(Inline)]
    public static implicit operator RegIndex(int src)
        => from((byte)src);

    [MethodImpl(Inline)]
    public static implicit operator byte(RegIndex src)
        => src.Encoded;

    [MethodImpl(Inline)]
    public static RegIndex operator ++(RegIndex src)
        => src.Encoded;

    [MethodImpl(Inline)]
    public static implicit operator RegIndex(RegIndexCode src)
        => new RegIndex(src);

    [MethodImpl(Inline)]
    public static implicit operator RegIndexCode(RegIndex src)
        => src.Code;

    public static RegIndex Empty
        => new (0);
}
