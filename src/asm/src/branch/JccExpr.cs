//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

[StructLayout(LayoutKind.Sequential, Pack=1)]
public readonly record struct JccExpr
{
    public readonly AsmMnemonic Instruction;

    public readonly JccOperand Operand;

    public JccExpr(AsmMnemonic mnemonic, JccOperand op)
    {
        Instruction = mnemonic;
        Operand = op;
    }        
}
