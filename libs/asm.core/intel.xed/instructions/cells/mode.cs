//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static MachineModes;

    partial class XedRules
    {
        partial struct InstCells
        {
            [MethodImpl(Inline), Op]
            public static MachineMode mode(in InstCells src)
            {
                var result = MachineModeClass.Default;
                for(var i=0; i<src.Count; i++)
                {
                    ref readonly var f = ref src[i];
                    if(f.IsExpr && f.Field == FieldKind.MODE)
                        result = f.ToCellExpr().Value;
                }
                return result;
            }
        }
    }
}