//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static AsmOpCodes;
using static sys;

partial class XedFields
{
    [MethodImpl(Inline), Op]
    public static AsmOpCodeIndex ocindex(in XedFieldState state)
    {
        var dst = AsmOpCodeIndex.Amd3dNow;
        ref readonly var map = ref state.MAP;
        ref readonly var vc = ref vexclass(state);
        switch(vc)
        {
            case XedVexClass.VV1:
                dst = index((VexMapKind)map);
                break;
            case XedVexClass.EVV:
                dst = index((EvexMapKind)map);
                break;
            case XedVexClass.XOPV:
                dst = index((XopMapKind)map);
                break;
            default:
                dst = (AsmOpCodeIndex)map;
                break;
        }

        return dst;
    }
}