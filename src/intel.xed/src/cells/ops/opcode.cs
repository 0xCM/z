//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedRules;
using static XedModels;

partial class XedCells
{    
    [MethodImpl(Inline), Op]
    public static AsmOpCode opcode(in InstCells src)
    {
        var vc = VexValid.None;
        var number = z8;
        var ocv = ocvalue(src);
        var ock = AsmOpCodeKind.None;
        for(var i=0; i<src.Count; i++)
        {
            ref readonly var part = ref src[i];
            if(part.IsExpr && part.Field == FieldKind.VEXVALID)
                vc = (VexValid)part.AsCellExpr().Value;
            if(part.IsExpr && part.Field == FieldKind.MAP)
                number = part.AsCellExpr().Value.ToByte();
        }

        switch(vc)
        {
            case VexValid.VV1:
                ock = AsmOpCodes.kind(AsmOpCodes.index((VexMapKind)number));
            break;
            case VexValid.XOPV:
                ock = AsmOpCodes.kind(AsmOpCodes.index((XopMapKind)number));
            break;
            case VexValid.EVV:
                ock = AsmOpCodes.kind(AsmOpCodes.index((EvexMapKind)number));
            break;
            default:
                ock = AsmOpCodes.kind((AsmOpCodeIndex)AsmOpCodes.basemap(ocv));
            break;
        }

        return new AsmOpCode(mode(src), ock, ocv);
    }
}
