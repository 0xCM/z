//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static AsmOpCodes;
using static XedModels;
using static sys;

partial class XedFields
{
    [MethodImpl(Inline), Op]
    public static AsmOpCodeIndex ocindex(in XedFieldState state)
    {
        var dst = AsmOpCodeIndex.Amd3dNow;
        ref readonly var map = ref state.MAP;
        ref readonly var vc = ref vexvalid(state);
        switch(vc)
        {
            case VexValid.VV1:
                dst = index((VexMapKind)map);
                break;
            case VexValid.EVV:
                dst = index((EvexMapKind)map);
                break;
            case VexValid.XOPV:
                dst = index((XopMapKind)map);
                break;
            default:
                dst = (AsmOpCodeIndex)map;
                break;
        }

        return dst;
    }
}