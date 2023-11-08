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
    public static bit @locked(in InstCells src)
    {
        var result = bit.Off;
        for(var i=0; i<src.Count; i++)
        {
            ref readonly var field = ref src[i];
            if(field.Field == FieldKind.LOCK)
            {
                result = field.AsCellExpr().Value;
                break;
            }
        }
        return result;
    }    
}
