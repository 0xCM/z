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
    public static EncodingOffsets offsets(in XedFieldState src)
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
}