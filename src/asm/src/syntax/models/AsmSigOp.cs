//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

[StructLayout(LayoutKind.Sequential, Size=2)]
public readonly record struct AsmSigOp
{
    public readonly AsmSigTokenKind Kind;

    public readonly byte Value;

    public readonly AsmModifierKind Modifier;

    [MethodImpl(Inline)]
    public AsmSigOp(AsmSigTokenKind kind, byte value, AsmModifierKind mod = 0)
    {
        Value = value;
        Kind = kind;
        Modifier = mod;
    }

    public AsmSigToken Token
    {
        [MethodImpl(Inline)]
        get => new (Kind, Value);
    }

    public ushort Id
    {
        [MethodImpl(Inline)]
        get => bits.join((byte)Value, (byte)Kind);
    }

    public bool IsModified
    {
        [MethodImpl(Inline)]
        get => Modifier != 0;
    }

    public bool IsMasked
    {
        [MethodImpl(Inline)]
        get => IsModified && (byte)Modifier <= (byte)AsmModifierKind.k1z;
    }

    [MethodImpl(Inline)]
    public AsmSigOp WithoutModifier()
        => new (Kind, Value);

    [MethodImpl(Inline)]
    public AsmSigOp WithModifier(AsmModifierKind mod)
        => new (Kind, Value, mod);

    public Hash16 Hash
    {
        [MethodImpl(Inline)]
        get => Id;
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

    public override int GetHashCode()
        => (int)Hash;

    [MethodImpl(Inline)]
    public bool Equals(AsmSigOp src)
        => sys.bw64(this) == sys.bw64(src);

    public string Format()
        => AsmSigs.format(this);

    public override string ToString()
        => Format();

    public static AsmSigOp Empty =>default;
}
