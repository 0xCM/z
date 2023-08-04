//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static sys;

[StructLayout(LayoutKind.Sequential, Pack=1)]
public record struct AsmSigExpr : IEquatable<AsmSigExpr>
{
    public const byte MaxOpCount = 5;

    public readonly AsmMnemonic Mnemonic;

    public AsmSigOpExpr Op0;

    public AsmSigOpExpr Op1;

    public AsmSigOpExpr Op2;

    public AsmSigOpExpr Op3;

    public AsmSigOpExpr Op4;

    public byte OpCount
    {
        [MethodImpl(Inline)]
        get => CalcOpCount();
    }

    [MethodImpl(Inline)]
    public AsmSigExpr(AsmMnemonic monic)
    {
        Mnemonic = monic;
        Op0 = AsmSigOpExpr.Empty;
        Op1 = AsmSigOpExpr.Empty;
        Op2 = AsmSigOpExpr.Empty;
        Op3 = AsmSigOpExpr.Empty;
        Op4 = AsmSigOpExpr.Empty;
    }

    [MethodImpl(Inline)]
    public AsmSigExpr(AsmMnemonic monic, AsmSigOpExpr op0)
    {
        Mnemonic = monic;
        Op0 = op0;
        Op1 = AsmSigOpExpr.Empty;
        Op2 = AsmSigOpExpr.Empty;
        Op3 = AsmSigOpExpr.Empty;
        Op4 = AsmSigOpExpr.Empty;
    }

    [MethodImpl(Inline)]
    public AsmSigExpr(AsmMnemonic monic, AsmSigOpExpr op0, AsmSigOpExpr op1)
    {
        Mnemonic = monic;
        Op0 = op0;
        Op1 = op1;
        Op2 = AsmSigOpExpr.Empty;
        Op3 = AsmSigOpExpr.Empty;
        Op4 = AsmSigOpExpr.Empty;
    }

    [MethodImpl(Inline)]
    public AsmSigExpr(AsmMnemonic monic, AsmSigOpExpr op0, AsmSigOpExpr op1, AsmSigOpExpr op2)
    {
        Mnemonic = monic;
        Op0 = op0;
        Op1 = op1;
        Op2 = op2;
        Op3 = AsmSigOpExpr.Empty;
        Op4 = AsmSigOpExpr.Empty;
    }

    [MethodImpl(Inline)]
    public AsmSigExpr(AsmMnemonic monic, AsmSigOpExpr op0, AsmSigOpExpr op1, AsmSigOpExpr op2, AsmSigOpExpr op3)
    {
        Mnemonic = monic;
        Op0 = op0;
        Op1 = op1;
        Op2 = op2;
        Op3 = op3;
        Op4 = AsmSigOpExpr.Empty;
    }

    [MethodImpl(Inline)]
    public AsmSigExpr(AsmMnemonic monic, AsmSigOpExpr op0, AsmSigOpExpr op1, AsmSigOpExpr op2, AsmSigOpExpr op3, AsmSigOpExpr op4)
    {
        Mnemonic = monic;
        Op0 = op0;
        Op1 = op1;
        Op2 = op2;
        Op3 = op3;
        Op4 = op4;
    }

    public Hash32 Hash
    {
        get => Mnemonic.Hash | Op0.Hash | Op1.Hash | Op2.Hash | Op3.Hash | Op4.Hash;
    }
    public AsmSigExpr WithOperand(byte n, AsmSigOpExpr op)
    {
        switch(n)
        {
            case 0:
                Op0 = op;
            break;
            case 1:
                Op1 = op;
            break;
            case 2:
                Op2 = op;
            break;
            case 3:
                Op3 = op;
            break;
            case 4:
                Op4 = op;
            break;
        }
        return this;
    }

    public ReadOnlySpan<AsmSigOpExpr> Operands()
    {
        var dst = alloc<AsmSigOpExpr>(OpCount);
        Operands(dst);
        return dst;
    }

    public override int GetHashCode()
        => Hash;

    public ref CharBlock64 OperandText(ref CharBlock64 dst)
    {
        var i=0u;
        AsmSigs.operands(this, ref i, dst.Data);
        return ref dst;
    }

    [MethodImpl(Inline)]
    byte CalcOpCount()
    {
        var count = z8;
        if(Op0.IsEmpty)
            return 0;
        if(Op1.IsEmpty)
            return 1;
        if(Op2.IsEmpty)
            return 2;
        if(Op3.IsEmpty)
            return 3;
        if(Op4.IsEmpty)
            return 4;

        return 5;
    }

    public readonly byte Operands(Span<AsmSigOpExpr> dst)
        => AsmSigs.operands(this,dst);

    public readonly bool IsEmpty
    {
        [MethodImpl(Inline)]
        get => Mnemonic.IsEmpty;
    }

    public readonly bool IsNonEmpty
    {
        [MethodImpl(Inline)]
        get => Mnemonic.IsNonEmpty;
    }

    public readonly bool Equals(AsmSigExpr src)
        => AsmSigs.equals(this,src);

    public readonly string Format()
        => AsmSigs.format(this);

    public readonly override string ToString()
        => Format();

    public static AsmSigExpr Empty
    {
        [MethodImpl(Inline)]
        get => new (AsmMnemonic.Empty);
    }
}
