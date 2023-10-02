//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static sys;
using static XedModels;

using N = XedModels.OpNameKind;

partial class Xed
{
    [Op]
    public static ref XedOperandState update(in EncodingOffsets src, AsmHexCode code, ref XedOperandState dst)
    {
        if(src.HasOpCode)
        {
            dst.POS_NOMINAL_OPCODE = (byte)src.OpCode;
            dst.NOMINAL_OPCODE = code[src.OpCode];
        }
        if(src.HasModRm)
        {
            dst.POS_MODRM = (byte)src.ModRm;
            dst.HAS_MODRM = bit.On;
            dst.MODRM_BYTE = code[src.ModRm];
        }
        if(src.HasSib)
        {
            dst.POS_SIB = (byte)src.Sib;
            var sib = (Sib)code[src.Sib];
            dst.SIBBASE = sib.Base;
            dst.SIBINDEX = sib.Index;
            dst.SIBSCALE = sib.Scale;
        }
        if(src.HasImm0)
        {
            dst.POS_IMM = (byte)src.Imm0;
            dst.IMM0 = bit.On;
        }
        if(src.HasImm1)
        {
            dst.POS_IMM1 = (byte)src.Imm1;
            dst.IMM1 = bit.On;
        }

        return ref dst;
    }

    [Op]
    public static EncodingOffsets offsets(in XedOperandState src)
    {
        var offsets = EncodingOffsets.Empty;
        offsets.OpCode = (sbyte)src.POS_NOMINAL_OPCODE;
        if(src.HAS_MODRM)
            offsets.ModRm = (sbyte)src.POS_MODRM;
        if(src.POS_SIB != 0)
            offsets.Sib = (sbyte)src.POS_SIB;
        if(src.POS_DISP != 0)
            offsets.Disp = (sbyte)src.POS_DISP;
        if(src.IMM0)
            offsets.Imm0 = (sbyte)src.POS_IMM;
        if(src.IMM1)
            offsets.Imm1 = (sbyte)src.POS_IMM1;
        return offsets;
    }

    [Op]
    public static Imm imm0(in XedOperandState state, in AsmHexCode code)
    {
        var dst = Imm.Empty;
        if(state.IMM0)
            dst = asm.imm(code, state.POS_IMM, state.IMM0SIGNED, Sizes.native(state.IMM_WIDTH));
        return dst;
    }

    [Op]
    public static Imm imm1(in XedOperandState state, in AsmHexCode code)
    {
        var dst = Imm.Empty;
        if(state.IMM1)
            dst = asm.imm(code, state.POS_IMM1, false, Sizes.native(state.IMM1_BYTES/8));
        return dst;
    }

    [Op]
    public static Disp disp(in XedOperandState state, in AsmHexCode code)
    {
        var val = Disp.Zero;
        if(state.DISP_WIDTH != 0)
        {
            var width = state.DISP_WIDTH;
            var size = width/8;
            var offset = state.POS_DISP;
            switch(size)
            {
                case 1:
                    val = new Disp((sbyte)code[offset], NativeSizeCode.W8);
                break;
                case 2:
                    val = new Disp(slice(code.Bytes, offset, size).TakeInt16(), NativeSizeCode.W16);
                break;
                case 4:
                    val = new Disp(slice(code.Bytes, offset, size).TakeInt32(), NativeSizeCode.W32);
                break;
                case 8:
                    val = new Disp(slice(code.Bytes, offset, size).TakeInt64(), NativeSizeCode.W64);
                break;
            }
        }

        return val;
    }

    [Op]
    public static EncodingExtract encoding(in XedOperandState state, AsmHexCode code)
    {
        var dst = EncodingExtract.Empty;
        dst.Code = code;
        dst.Offsets = offsets(state);
        dst.OpCode = code[state.POS_NOMINAL_OPCODE];

        Demand.eq(nameof(state.NOMINAL_OPCODE), (byte)dst.OpCode, state.NOMINAL_OPCODE);

        if(state.DISP_WIDTH > 0)
            dst.Disp = disp(state, code);
        if(state.IMM0)
            dst.Imm = imm0(state, code);
        if(state.IMM1)
            dst.Imm1 = imm1(state, code);
        if(state.HAS_SIB)
            dst.Sib = (Sib)code[state.POS_SIB];
        if(state.HAS_MODRM)
            dst.ModRm = (ModRm)code[state.POS_MODRM];

        return dst;
    }

    public static Index<Operand> operands(in XedOperandState state, in AsmHexCode code)
    {
        var _ops = list<Operand>();
        if(state.IMM0)
            _ops.Add(new Operand(N.IMM0, imm0(state, code)));

        if(state.IMM1)
            _ops.Add(new Operand(N.IMM1, imm1(state, code)));

        if(state.DISP_WIDTH != 0)
            _ops.Add(new Operand(N.DISP, disp(state, code)));

        if(state.BASE0 != 0)
            _ops.Add(new Operand(N.BASE0, state.BASE0));

        if(state.BASE1 != 0)
            _ops.Add(new Operand(N.BASE1, state.BASE1));

        if(state.SCALE != 0)
            _ops.Add(new Operand(N.SCALE, (MemoryScale)state.SCALE));

        if(state.INDEX != 0)
            _ops.Add(new Operand(N.INDEX, state.INDEX));

        if(state.REG0 != 0)
            _ops.Add(new Operand(N.REG0, state.REG0));

        if(state.REG1 != 0)
            _ops.Add(new Operand(N.REG1, state.REG1));

        if(state.REG2 != 0)
            _ops.Add(new Operand(N.REG2, state.REG2));

        if(state.REG3 != 0)
            _ops.Add(new Operand(N.REG3, state.REG3));

        if(state.REG4 != 0)
            _ops.Add(new Operand(N.REG4, state.REG4));

        if(state.REG5 != 0)
            _ops.Add(new Operand(N.REG5, state.REG5));

        if(state.REG6 != 0)
            _ops.Add(new Operand(N.REG6, state.REG6));

        if(state.REG7 != 0)
            _ops.Add(new Operand(N.REG7, state.REG7));

        if(state.REG8 != 0)
            _ops.Add(new Operand(N.REG8, state.REG8));

        if(state.REG9 != 0)
            _ops.Add(new Operand(N.REG9, state.REG9));

        return _ops.ToArray();
    }    
}
