//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class XedDb
    {
        public void EmitArtifacts()
        {
            exec(PllExec,
                EmitRuleSchema,
                () => Channel.TableEmit(Xed.Views.TypeTableRows, Paths.DbTable<TypeTableRow>()),
                EmitLayouts
            );
        }

        public void EmitRuleSchema()
        {
            exec(PllExec,
                () => EmitRuleMetrics(CellTables),
                () => EmitTableStats(CellTables),
                () => EmitGrids(CellTables)
                );
        }
    }
}