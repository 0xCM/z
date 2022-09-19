//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    partial class XedRules
    {
        partial struct InstCells
        {
            [MethodImpl(Inline), Op]
            public static ModIndicator mod(in InstCells src)
            {
                var result = false;
                var dst = ModIndicator.Empty;
                for(var i=0; i<src.Count; i++)
                {
                    ref readonly var field = ref src[i];
                    if(field.Field == FieldKind.MOD && field.IsExpr)
                    {
                        var expr = field.ToCellExpr();
                        if(expr.Operator == OperatorKind.Ne)
                        {
                            dst = ModKind.NE3;
                            result = true;
                            break;
                        }
                        else if(expr.Operator == OperatorKind.Eq)
                        {
                            dst = ModKind.MOD3;
                            result = true;
                            break;
                        }
                    }
                }
                return dst;
            }
        }
    }
}