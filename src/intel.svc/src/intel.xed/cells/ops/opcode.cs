//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedRules;
using static XedModels;

partial struct XedCells
{    
    [MethodImpl(Inline), Op]
    public static AsmOpCode opcode(in InstCells src)
    {
        var vc = XedVexClass.None;
        var number = z8;
        var ocv = ocvalue(src);
        var ock = AsmOpCodeKind.None;
        for(var i=0; i<src.Count; i++)
        {
            ref readonly var part = ref src[i];
            if(part.IsExpr && part.Field == FieldKind.VEXVALID)
                vc = (XedVexClass)part.ToCellExpr().Value;
            if(part.IsExpr && part.Field == FieldKind.MAP)
                number = part.ToCellExpr().Value.ToByte();
        }

        switch(vc)
        {
            case XedVexClass.VV1:
                ock = AsmOpCodes.kind(AsmOpCodes.index((VexMapKind)number));
            break;
            case XedVexClass.XOPV:
                ock = AsmOpCodes.kind(AsmOpCodes.index((XopMapKind)number));
            break;
            case XedVexClass.EVV:
                ock = AsmOpCodes.kind(AsmOpCodes.index((EvexMapKind)number));
            break;
            default:
                ock = AsmOpCodes.kind((AsmOpCodeIndex)AsmOpCodes.basemap(ocv));
            break;
        }

        return new AsmOpCode(mode(src), ock, ocv);
    }
}

