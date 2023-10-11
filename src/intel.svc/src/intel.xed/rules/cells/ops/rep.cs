//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;
using static XedRules;
using static sys;

partial struct XedCells
{
    [MethodImpl(Inline), Op]
    public static RepIndicator @rep(in XedCells src)
    {
        var dst = RepIndicator.Empty;
        for(var i=0; i<src.Count; i++)
        {
            ref readonly var field = ref src[i];
            if(field.Field == FieldKind.REP)
            {
                dst = (RepPrefix)field.ToCellExpr().Value;
                break;
            }
        }
        return dst;
    }
}

