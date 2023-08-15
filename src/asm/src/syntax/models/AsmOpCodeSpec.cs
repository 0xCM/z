//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static sys;
using static AsmOpCodes;

public struct AsmOpCodeSpec : IEquatable<AsmOpCodeSpec>
{
    public const byte TokenCapacity = 31;

    Cell512 Data;

    [MethodImpl(Inline)]
    public AsmOpCodeSpec(Cell512 data)
    {
        Data = data;
    }

    [MethodImpl(Inline)]
    public AsmOpCodeSpec(ReadOnlySpan<AsmOcToken> tokens)
    {
        Data = first(recover<AsmOcToken,Cell512>(tokens));
        ref var _tokens = ref @as<Cell512,AsmOcToken>(Data);
        var counter = z8;
        for(var i=0; i<TokenCapacity; i++)
        {
            if(skip(_tokens,i).Id != 0)
                counter++;
            else
                break;
        }

        TokenCount = counter;
    }

    [MethodImpl(Inline), UnscopedRef]
    Span<AsmOcToken> Buffer()
        => recover<AsmOcToken>(bytes(Data));

    ref ushort Settings
    {
        [MethodImpl(Inline), UnscopedRef]
        get => ref seek(recover<ushort>(bytes(Data)), TokenCapacity-1);
    }

    [MethodImpl(Inline), UnscopedRef]
    public ReadOnlySpan<AsmOcToken> Tokens()
        => Buffer();

    [MethodImpl(Inline), UnscopedRef]
    public Span<AsmOcToken> Tokens(AsmOcTokenKind kind)
        => Tokens().Where(t => t.Kind == kind);

    public OpCodeValue OcValue()
    {
        var hex = Tokens(AsmOcTokenKind.Hex8);
        var count = hex.Length;
        var dst = OpCodeValue.Empty;
        switch(count)
        {
            case 1:
                dst = new OpCodeValue((byte)skip(hex, 0));
            break;
            case 2:
                dst = new OpCodeValue((byte)skip(hex, 0), (byte)skip(hex, 1));
            break;
            case 3:
                dst = new OpCodeValue((byte)skip(hex, 0), (byte)skip(hex, 1), (byte)skip(hex, 2));
            break;
            case 4:
                dst = new OpCodeValue((byte)skip(hex, 0), (byte)skip(hex, 1), (byte)skip(hex, 2), (byte)skip(hex, 3));
            break;
        }
        return dst;
    }

    public ref byte TokenCount
    {
        [MethodImpl(Inline), UnscopedRef]
        get => ref @as<byte>(Settings);
    }

    public ref AsmOcToken this[uint i]
    {
        [MethodImpl(Inline), UnscopedRef]
        get => ref seek(Buffer(), i);
    }

    public ref AsmOcToken this[int i]
    {
        [MethodImpl(Inline), UnscopedRef]
        get => ref seek(Buffer(), i);
    }

    public bool IsEmpty
    {
        [MethodImpl(Inline)]
        get => TokenCount == 0;
    }

    public bool IsNonEmpty
    {
        [MethodImpl(Inline)]
        get => TokenCount != 0;
    }

    public AsmOcFlags Flags()
    {
        var count = TokenCount;
        var flags = AsmOcFlags.None;
        for(var i=0; i<count; i++)
            flags |= (AsmOcFlags)Pow2.pow((byte)this[i].Kind);
        return flags;
    }

    public Hex32 Hash
        => Data.GetHashCode();

    [MethodImpl(Inline)]
    public bool Equals(AsmOpCodeSpec src)
        => Data.Equals(src.Data);

    public override bool Equals(object src)
        => src is AsmOpCodeSpec x && Equals(x);

    public override int GetHashCode()
        => (int)Hash;

    public readonly string Format()
        => SdmOpCodes.format(this);

    public readonly override string ToString()
        => Format();

    [MethodImpl(Inline)]
    public static bool operator ==(AsmOpCodeSpec a, AsmOpCodeSpec b)
        => a.Equals(b);

    [MethodImpl(Inline)]
    public static bool operator !=(AsmOpCodeSpec a, AsmOpCodeSpec b)
        => !a.Equals(b);

    public static AsmOpCodeSpec Empty => new AsmOpCodeSpec(sys.empty<AsmOcToken>());
}
