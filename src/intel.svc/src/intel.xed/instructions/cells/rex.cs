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
            public static BitIndicator rexw(in InstCells src)
            {
                var dst = BitIndicator.Empty;
                for(var i=0; i<src.Count; i++)
                {
                    ref readonly var f = ref src[i];
                    if(f.IsExpr && f.Field == FieldKind.REXW)
                    {
                        dst = BitIndicator.defined(f.ToCellExpr().Value);
                        break;
                    }
                }
                return dst;
            }

            [MethodImpl(Inline), Op]
            public static BitIndicator rexr(in InstCells src)
            {
                var dst = BitIndicator.Empty;
                for(var i=0; i<src.Count; i++)
                {
                    ref readonly var f = ref src[i];
                    if(f.IsExpr && f.Field == FieldKind.REXR)
                    {
                        dst = BitIndicator.defined(f.ToCellExpr().Value);
                        break;
                    }
                }
                return dst;
            }

            [MethodImpl(Inline), Op]
            public static BitIndicator rexb(in InstCells src)
            {
                var dst = BitIndicator.Empty;
                for(var i=0; i<src.Count; i++)
                {
                    ref readonly var f = ref src[i];
                    if(f.IsExpr && f.Field == FieldKind.REXB)
                    {
                        dst = BitIndicator.defined(f.ToCellExpr().Value);
                        break;
                    }
                }
                return dst;
            }

            [MethodImpl(Inline), Op]
            public static BitIndicator rexx(in InstCells src)
            {
                var dst = BitIndicator.Empty;
                for(var i=0; i<src.Count; i++)
                {
                    ref readonly var f = ref src[i];
                    if(f.IsExpr && f.Field == FieldKind.REXX)
                    {
                        dst = BitIndicator.defined(f.ToCellExpr().Value);
                        break;
                    }
                }
                return dst;
            }
        }
    }
}