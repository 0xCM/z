//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using Asm.Operands;

    using static sys;

    [ApiHost]
    public class AsmSpecs
    {
        const NumericKind Closure = UnsignedInts;

        // and r32, imm32 | 81 /4 id
        [MethodImpl(Inline), Op]
        public static AsmInstruction and(r32 a, Imm32 b)
            => inst("and", AsmOpCodeSpec.Empty, a, b);

        [Op]
        public static AsmInstruction inst(in AsmMnemonic mnemonic, in AsmOpCodeSpec opcode, params AsmOperand[] ops)
        {
            var count = ops.Length;
            switch(count)
            {
                case 0:
                    return inst(mnemonic, opcode, out _);
                case 1:
                    return inst(mnemonic, opcode, skip(ops,0), out _);
                case 2:
                    return inst(mnemonic, opcode, skip(ops,0), skip(ops,1), out _);
                case 3:
                    return inst(mnemonic, opcode, skip(ops,0), skip(ops,1), skip(ops,2), out _);
                case 4:
                    return inst(mnemonic, opcode, skip(ops,0), skip(ops,1), skip(ops,2), skip(ops,3), out _);
            }
            return AsmInstruction.Empty;
        }

        [MethodImpl(Inline), Op]
        public static AsmInstruction inst(in AsmMnemonic mnemonic, in AsmOpCodeSpec opcode, in AsmOperands ops)
            => new AsmInstruction(mnemonic, opcode, ops);

        [MethodImpl(Inline), Op]
        public static AsmInstruction inst(in AsmMnemonic mnemonic, in AsmOpCodeSpec opcode, out AsmInstruction dst)
        {
            dst = inst(mnemonic, opcode, AsmOperands.Empty);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static AsmInstruction inst(in AsmMnemonic mnemonic, in AsmOpCodeSpec opcode, in AsmOperand op0, out AsmInstruction dst)
        {
            dst.Mnemonic = mnemonic;
            dst.OpCode = opcode;
            dst.Operands = AsmOperands.Empty;
            ops(op0, ref dst.Operands);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static AsmInstruction inst(in AsmMnemonic mnemonic, in AsmOpCodeSpec opcode, in AsmOperand op0, in AsmOperand op1, out AsmInstruction dst)
        {
            dst.Mnemonic = mnemonic;
            dst.OpCode = opcode;
            dst.Operands = AsmOperands.Empty;
            ops(op0, op1, ref dst.Operands);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static AsmInstruction inst(in AsmMnemonic mnemonic, in AsmOpCodeSpec opcode, in AsmOperand op0, in AsmOperand op1, in AsmOperand op2, out AsmInstruction dst)
        {
            dst.Mnemonic = mnemonic;
            dst.OpCode = opcode;
            dst.Operands = AsmOperands.Empty;
            ops(op0, op1, op2, ref dst.Operands);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static AsmInstruction inst(in AsmMnemonic mnemonic, in AsmOpCodeSpec opcode, in AsmOperand op0, in AsmOperand op1, in AsmOperand op2, in AsmOperand op3, out AsmInstruction dst)
        {
            dst.Mnemonic = mnemonic;
            dst.OpCode = opcode;
            dst.Operands = AsmOperands.Empty;
            ops(op0, op1, op2, op3, ref dst.Operands);
            return dst;
        }

        [MethodImpl(Inline)]
        public static ref AsmOperands ops(in AsmOperand op0, ref AsmOperands dst)
        {
            dst.Op0 = op0;
            dst.Op1 = AsmOperand.Empty;
            dst.Op2 = AsmOperand.Empty;
            dst.Op3 = AsmOperand.Empty;
            dst.OpCount = 1;
            return ref dst;
        }

        [MethodImpl(Inline)]
        public static ref AsmOperands ops(in AsmOperand op0, in AsmOperand op1, ref AsmOperands dst)
        {
            dst.Op0 = op0;
            dst.Op1 = op1;
            dst.Op2 = AsmOperand.Empty;
            dst.Op3 = AsmOperand.Empty;
            dst.OpCount = 2;
            return ref dst;
        }

        [MethodImpl(Inline)]
        public static ref AsmOperands ops(in AsmOperand op0, in AsmOperand op1, in AsmOperand op2, ref AsmOperands dst)
        {
            dst.Op0 = op0;
            dst.Op1 = op1;
            dst.Op2 = op2;
            dst.Op3 = AsmOperand.Empty;
            dst.OpCount = 3;
            return ref dst;
        }

        [MethodImpl(Inline)]
        public static ref AsmOperands ops(in AsmOperand op0, in AsmOperand op1, in AsmOperand op2, in AsmOperand op3, ref AsmOperands dst)
        {
            dst.Op0 = op0;
            dst.Op1 = op1;
            dst.Op2 = op2;
            dst.Op3 = op3;
            dst.OpCount = 4;
            return ref dst;
        }
   }
}