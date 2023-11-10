//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static XedModels;

partial class XedFields
{
    [Op]
    public static EncodingExtract encoding(in XedFieldState state, AsmHexCode code)
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
}