//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

[StructLayout(LayoutKind.Sequential,Pack=1)]
public struct AsmInstruction : IAsmSourcePart
{
    public static string format(in AsmInstruction src)
    {
        var dst = text.buffer();
        ref readonly var ops = ref src.Operands;
        var count = ops.OpCount;
        dst.Append(src.Mnemonic.Format(MnemonicCase.Lowercase));
        if(count != 0)
        {
            dst.Append(Chars.Space);
            dst.Append(src.Operands.Format());
        }
        return dst.Emit();
    }

    public AsmMnemonic Mnemonic;

    public AsmOpCodeSpec OpCode;

    public AsmOperands Operands;

    public AsmInstruction(AsmMnemonic mnemonic, AsmOpCodeSpec opcode, AsmOperands ops)
    {
        Mnemonic = mnemonic;
        OpCode = opcode;
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
        => format(this);

    public override string ToString()
        => Format();

    public static AsmInstruction Empty => default;

    public AsmCellKind PartKind
        => AsmCellKind.Instruction;
}
