//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;
using static XedModels.OpNameKind;

using K = XedModels.OpKind;

partial class XedPatterns
{
    [Op]
    public static K opkind(OpNameKind src)
    {
        var dst = K.None;
        switch(src)
        {
            case REG0:
            case REG1:
            case REG2:
            case REG3:
            case REG4:
            case REG5:
            case REG6:
            case REG7:
            case REG8:
            case REG9:
                dst = K.Reg;
            break;
            case MEM0:
            case MEM1:
                dst = K.Mem;
            break;
            case IMM0:
            case IMM1:
            case IMM2:
                dst = K.Imm;
            break;
            case RELBR:
                dst = K.RelBr;
            break;
            case SEG0:
            case SEG1:
                dst = K.Seg;
            break;
            case AGEN:
                dst = K.Agen;
            break;
            case PTR:
                dst = K.Ptr;
            break;
            case BASE0:
            case BASE1:
                dst = K.Base;
            break;
            case INDEX:
                dst = K.Index;
            break;
            case SCALE:
                dst = K.Scale;
            break;
            case DISP:
                dst = K.Disp;
            break;
        }
        return dst;
    }
}
