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
    public static Imm imm0(in XedFieldState state, in AsmHexCode code)
    {
        var dst = Imm.Empty;
        if(state.IMM0)
            dst = asm.imm(code, state.POS_IMM, state.IMM0SIGNED, Sizes.native(state.IMM_WIDTH));
        return dst;
    }

    [Op]
    public static Imm imm1(in XedFieldState state, in AsmHexCode code)
    {
        var dst = Imm.Empty;
        if(state.IMM1)
            dst = asm.imm(code, state.POS_IMM1, false, Sizes.native(state.IMM1_BYTES/8));
        return dst;
    }
}