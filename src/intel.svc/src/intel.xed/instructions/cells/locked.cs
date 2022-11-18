//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        partial struct InstCells
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
                        result = field.ToCellExpr().Value;
                        break;
                    }
                }
                return result;
            }
        }
    }
}