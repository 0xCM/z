//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

[StructLayout(LayoutKind.Sequential,Pack=1)]
public record struct AsmInstruction : IAsmSourcePart
{
    public AsmMnemonic Mnemonic;

    public AsmOperandSet Operands;

    public AsmInstruction(AsmMnemonic mnemonic, AsmOperandSet ops)
    {
        Mnemonic = mnemonic;
        Operands = ops;
    }

    public bool IsEmpty
    {
        [MethodImpl(Inline)]
        get => Operands.IsEmpty;
    }

    public bool IsNonEmpty
    {
        [MethodImpl(Inline)]
        get => Operands.IsNonEmpty;
    }

    public string Format()
        => AsmRender.format(this);

    public override string ToString()
        => Format();

    public AsmCellKind PartKind
        => AsmCellKind.Instruction;

    public static AsmInstruction Empty => default;
}
