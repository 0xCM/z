//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

partial class XedFields
{
    [Op]
    public static ref XedFieldState update(in EncodingOffsets src, AsmHexCode code, ref XedFieldState dst)
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
}