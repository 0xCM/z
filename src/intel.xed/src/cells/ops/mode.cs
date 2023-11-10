//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static MachineModes;
using static XedRules;
using static XedModels;

partial class XedCells
{
    [MethodImpl(Inline), Op]
    public static MachineMode mode(in InstCells src)
    {
        var result = MachineModeClass.Mode64;
        for(var i=0; i<src.Count; i++)
        {
            ref readonly var f = ref src[i];
            if(f.IsExpr && f.Field == FieldKind.MODE)
            {
                result = f.AsCellExpr().Value;
                break;
            }
        }
        return result;
    }    
}
