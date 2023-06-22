//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedLiterals;

    partial class XedRules
    {
        partial struct InstCells
        {
            [MethodImpl(Inline), Op]
            public static XedOpCode opcode(in InstCells src)
            {
                var vc = XedVexClass.None;
                var number = z8;
                var ocv = ocvalue(src);
                var ock = XedOpCodeKind.None;
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
                        ock = AsmOpCodeMaps.kind(AsmOpCodeMaps.index((VexMapKind)number));
                    break;
                    case XedVexClass.XOPV:
                        ock = AsmOpCodeMaps.kind(AsmOpCodeMaps.index((XopMapKind)number));
                    break;
                    case XedVexClass.EVV:
                    case XedVexClass.KVV:
                        ock = AsmOpCodeMaps.kind(AsmOpCodeMaps.index((EvexMapKind)number));
                    break;
                    default:
                        ock = AsmOpCodeMaps.kind((AsmOpCodeIndex)AsmOpCodeMaps.basemap(ocv));
                    break;
                }

                return new XedOpCode(InstCells.mode(src), ock, ocv);
            }
        }
    }
}