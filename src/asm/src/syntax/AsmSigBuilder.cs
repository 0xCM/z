//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using Operands;

using static AsmSigs;

public struct AsmSigBuilder
{
    public static AsmSigBuilder init(AsmMnemonic mnemonic)
        => new(mnemonic);
    
    readonly AsmMnemonic Mnemonic;

    AsmSigOps Operands;

    byte Index;

    [MethodImpl(Inline)]
    AsmSigBuilder(AsmMnemonic mnemonic)
    {
        Mnemonic = mnemonic;
        Operands = default;
        Index = 0;
    }

    public AsmSigBuilder WithOperand(Imm8 src)
    {
        Operands[Index++] = sig(src);
        return this;
    }

    public AsmSigBuilder WithOperand(Imm16 src)
    {
        Operands[Index++] = sig(src);
        return this;
    }

    public AsmSigBuilder WithOperand(Imm32 src)
    {
        Operands[Index++] = sig(src);
        return this;
    }

    public AsmSigBuilder WithOperand(Imm64 src)
    {
        Operands[Index++] = sig(src);
        return this;
    }

    public AsmSigBuilder WithOperand(r8 src)
    {
        Operands[Index++] = sig(src);
        return this;
    }


    public AsmSigBuilder WithOperand(r16 src)
    {
        Operands[Index++] = sig(src);
        return this;
    }

    public AsmSigBuilder WithOperand(r32 src)
    {
        Operands[Index++] = sig(src);
        return this;
    }

    public AsmSigBuilder WithOperand(r64 src)
    {
        Operands[Index++] = sig(src);
        return this;
    }

    public AsmSigBuilder WithOperand(xmm src)
    {
        Operands[Index++] = sig(src);
        return this;
    }

    public AsmSigBuilder WithOperand(ymm src)
    {
        Operands[Index++] = sig(src);
        return this;
    }

    public AsmSigBuilder WithOperand(zmm src)
    {
        Operands[Index++] = sig(src);
        return this;
    }

    public AsmSigBuilder WithOperand(al src)
    {
        Operands[Index++] = sig(src);
        return this;
    }

    public AsmSigBuilder WithOperand(ax src)
    {
        Operands[Index++] = sig(src);
        return this;
    }

    public AsmSigBuilder WithOperand(dx src)
    {
        Operands[Index++] = sig(src);
        return this;
    }

    public AsmSigBuilder WithOperand(eax src)
    {
        Operands[Index++] = sig(src);
        return this;
    }

    public AsmSigBuilder WithOperand(edx src)
    {
        Operands[Index++] = sig(src);
        return this;
    }

    public AsmSigBuilder WithOperand(rax src)
    {
        Operands[Index++] = sig(src);
        return this;
    }

    public AsmSigBuilder WithOperand(ds src)
    {
        Operands[Index++] = sig(src);
        return this;
    }

    public AsmSigBuilder WithOperand(es src)
    {
        Operands[Index++] = sig(src);
        return this;
    }

    public AsmSigBuilder WithOperand(fs src)
    {
        Operands[Index++] = sig(src);
        return this;
    }

    public AsmSigBuilder WithOperand(gs src)
    {
        Operands[Index++] = sig(src);
        return this;
    }

    public AsmSigBuilder WithOperand(ss src)
    {
        Operands[Index++] = sig(src);
        return this;
    }

    public AsmSigBuilder WithOperand(cs src)
    {
        Operands[Index++] = sig(src);
        return this;
    }

    public AsmSigBuilder WithOperand(cl src)
    {
        Operands[Index++] = sig(src);
        return this;
    }

    public AsmSigBuilder WithOperand(m8 src)
    {
        Operands[Index++] = sig(src);
        return this;
    }

    public AsmSigBuilder WithOperand(m16 src)
    {
        Operands[Index++] = sig(src);
        return this;
    }

    public AsmSigBuilder WithOperand(m32 src)
    {
        Operands[Index++] = sig(src);
        return this;
    }

    public AsmSigBuilder WithOperand(m64 src)
    {
        Operands[Index++] = sig(src);
        return this;
    }

    public AsmSigBuilder WithOperand(m128 src)
    {
        Operands[Index++] = sig(src);
        return this;
    }

    public AsmSigBuilder WithOperand(m256 src)
    {
        Operands[Index++] = sig(src);
        return this;
    }

    public AsmSigBuilder WithOperand(m512 src)
    {
        Operands[Index++] = sig(src);
        return this;
    }

    public AsmSigBuilder WithOperand(Rel8 src)
    {
        Operands[Index++] = sig(src);
        return this;
    }

    public AsmSigBuilder WithOperand(Rel16 src)
    {
        Operands[Index++] = sig(src);
        return this;
    }

    public AsmSigBuilder WithOperand(Rel32 src)
    {
        Operands[Index++] = sig(src);
        return this;
    }
}
