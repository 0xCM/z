//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;
using static XedRules;

using K = XedRules.FieldKind;
using N = XedModels.OpNameKind;

partial class XedPatterns
{
    [Op]
    public static OpName opname(FieldKind src)
    {
        var name = OpNameKind.None;
        switch(src)
        {
            case K.REG0:
                name = N.REG0;
            break;
            case K.REG1:
                name = N.REG1;
            break;
            case K.REG2:
                name = N.REG2;
            break;
            case K.REG3:
                name = N.REG3;
            break;
            case K.REG4:
                name = N.REG4;
            break;
            case K.REG5:
                name = N.REG5;
            break;
            case K.REG6:
                name = N.REG6;
            break;
            case K.REG7:
                name = N.REG7;
            break;
            case K.REG8:
                name = N.REG8;
            break;
            case K.MEM0:
                name = N.MEM0;
            break;
            case K.MEM1:
                name = N.MEM1;
            break;
            case K.IMM0:
                name = N.IMM0;
            break;
            case K.IMM1:
                name = N.IMM1;
            break;
            case K.RELBR:
                name = N.RELBR;
            break;
            case K.BASE0:
                name = N.BASE0;
            break;
            case K.BASE1:
                name = N.BASE1;
            break;
            case K.SEG0:
                name = N.SEG0;
            break;
            case K.SEG1:
                name = N.SEG1;
            break;
            case K.AGEN:
                name = N.AGEN;
            break;
            case K.PTR:
                name = N.PTR;
            break;
            case K.INDEX:
                name = N.INDEX;
            break;
            case K.SCALE:
                name = N.SCALE;
            break;
            case K.DISP:
                name = N.DISP;
            break;
        }
        return name;
    }
}
