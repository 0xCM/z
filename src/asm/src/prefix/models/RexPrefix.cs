//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static sys;

using F = RexFields;

using static AsmPrefixTokens;

/// <summary>
/// REX = [0100 | W:4 | R:3 | X:2 | B:1]
/// </summary>
[ApiComplete]
public record struct RexPrefix : IAsmPrefix<RexPrefix>, IAsmByte<RexPrefix>
{
    [MethodImpl(Inline)]
    public static RexPrefix init()
        => new (0x40);

    byte Data;

    [MethodImpl(Inline)]
    public RexPrefix(byte src)
        => Data = src;

    [MethodImpl(Inline)]
    public RexPrefix(bit b, bit x, bit r, bit w)
    {
        Data = math.or(bit.pack(b,x,r,w), (byte)0x40);
    }

    public bit W
    {
        [MethodImpl(Inline)]
        get => bits.test(Data, F.W);

        [MethodImpl(Inline)]
        set => Data = bits.set(Data, F.W, value);
    }

    public bit R
    {
        [MethodImpl(Inline)]
        get => bits.test(Data, F.R);

        [MethodImpl(Inline)]
        set => Data = bits.set(Data, F.R, value);
    }

    public bit X
    {
        [MethodImpl(Inline)]
        get => bits.test(Data, F.X);

        [MethodImpl(Inline)]
        set => Data = bits.set(Data, F.X, value);
    }

    public bit B
    {
        [MethodImpl(Inline)]
        get => bits.test(Data, F.B);

        [MethodImpl(Inline)]
        set => Data = bits.set(Data, F.B, value);
    }

    public readonly byte Encoded
    {
        [MethodImpl(Inline)]
        get => Data;
    }

    public bool IsEmpty
    {
        [MethodImpl(Inline)]
        get => Data == 0;
    }

    public bool IsNonEmpty
    {
        [MethodImpl(Inline)]
        get => Data != 0;
    }

    [MethodImpl(Inline)]
    public byte Value()
        => Data;

    public string Format()
        => AsmPrefixByte.format(this);

    public string ToBitString()
        => BitRender.format8x4(Data);

    public override string ToString()
        => Format();

    [MethodImpl(Inline)]
    public static implicit operator Hex8(RexPrefix src)
        => src.Data;

    [MethodImpl(Inline)]
    public static implicit operator RexPrefix(RexPrefixCode src)
        => new ((byte)src);

    [MethodImpl(Inline)]
    public static implicit operator byte(RexPrefix src)
        => src.Data;

    [MethodImpl(Inline)]
    public static implicit operator RexPrefix(byte src)
        => new (src);

    public static RexPrefix Empty
        => new (0);

    [MethodImpl(Inline), Op]
    public static ReadOnlySpan<RexPrefix> Range()
        => recover<RexPrefix>(RexPrefix._Range);

    static ReadOnlySpan<byte> _Range
        => new byte[16]{0x40,0x41,0x42,0x43,0x44,0x45,0x46,0x47,0x48,0x49,0x4A,0x4B,0x4C,0x4D,0x4E,0x4F};
}
