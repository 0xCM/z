//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

[StructLayout(LayoutKind.Sequential, Size=2, Pack =1)]
public readonly record struct AsmSigToken : IKindedToken<AsmSigTokenKind,byte>
{
    public readonly AsmSigTokenKind Kind;

    public readonly byte Value;

    [MethodImpl(Inline)]
    public AsmSigToken(AsmSigTokenKind kind, byte value)
    {
        Value = value;
        Kind = kind;
    }

    public uint Id
    {
        [MethodImpl(Inline)]
        get => bits.join((byte)Value, (byte)Kind);
    }

    AsmSigTokenKind IKinded<AsmSigTokenKind>.Kind
        => Kind;
    
    byte IValued<byte>.Value
        => Value;

    [MethodImpl(Inline)]
    public int CompareTo(AsmSigToken src)
    {
        var result = ((byte)Kind).CompareTo((byte)src.Kind);
        if(result == 0)
            result = Value.CompareTo(src.Value);
        return result;
    }

    public bool IsEmpty
    {
        [MethodImpl(Inline)]
        get => Kind == 0;
    }

    public bool IsNonEmpty
    {
        [MethodImpl(Inline)]
        get => Kind != 0;
    }

    [MethodImpl(Inline)]
    public bool Equals(AsmSigToken src)
        => Kind == src.Kind && Value == src.Value;

    public Hash32 Hash
    {
        [MethodImpl(Inline)]
        get => sys.bw16(this);
    }

    public override int GetHashCode()
        => Hash;

    public string Format()
        => AsmSigs.format(this);

    public override string ToString()
        => Format();

    [MethodImpl(Inline)]
    public static implicit operator KindedToken<AsmSigTokenKind,byte>(AsmSigToken src)
        => Tokens.token(src.Kind, src.Value);

    [MethodImpl(Inline)]
    public static implicit operator AsmSigToken(KindedToken<AsmSigTokenKind,byte> src)
        => new(src.Kind,src.Value);

    public static AsmSigToken Empty => default;
}
