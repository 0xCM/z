//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedModels;

    partial class XedPatterns
    {
        [Op]
        public static bool mode(in InstPatternBody src, out MachineMode dst)
        {
            dst = MachineMode.Default;
            var found = false;
            for(var i=0; i<src.CellCount; i++)
            {
                ref readonly var cell = ref src[i];
                if(cell.Field == FieldKind.MODE)
                {
                    dst = cell.AsMode();
                    found = true;
                    break;
                }
            }

            return found;
        }
    }
}