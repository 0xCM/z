//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedRules
    {
        partial struct InstCells
        {
            [MethodImpl(Inline), Op]
            public static ChipCode chip(in InstCells src)
            {
                var dst = ChipCode.INVALID;
                for(var i=0; i<src.Count; i++)
                {
                    ref readonly var f = ref src[i];

                    if(f.IsExpr && f.Field == FieldKind.CHIP)
                    {
                        dst = f.ToCellExpr().Value;
                        break;
                    }
                }
                return dst;
            }
        }
    }
}