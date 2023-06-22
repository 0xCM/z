//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedGrids;

    partial class XedDb
    {
        public void EmitGrids(CellTables src)
            => EmitGrids(CalcGrids(src));

        public void EmitGrids(Index<RuleGrid> src)
        {
            var kGrid = src.Count;
            var dst = text.emitter();
            var counter = 0u;
            for(var i=0; i<kGrid; i++)
            {
                ref readonly var grid = ref src[i];
                ref readonly var kRows = ref grid.RowCount;
                ref readonly var kCols = ref grid.ColCount;
                ref readonly var cells = ref grid.Cells;
                var gc = 0;
                for(var j=0; j<kRows; j++)
                {
                    for(var k=0; k<kCols; k++,gc++, counter++)
                    {
                        ref readonly var cell = ref cells[gc];
                        if(cell.IsEmpty)
                            continue;

                        dst.WriteLine(cell.Format());
                    }
                }
            }
            Channel.FileEmit(dst.Emit(), counter, Paths.DbTarget("rules.grids", FileKind.Csv));
        }
    }
}