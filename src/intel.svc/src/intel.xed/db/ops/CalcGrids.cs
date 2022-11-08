//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedGrids;
    using static MemDb;
    using static core;

    partial class XedDb
    {
        public Index<RuleGrid> CalcGrids(CellTables src)
        {
            return Data(nameof(CalcGrids), Calc);

            Index<RuleGrid> Calc()
            {
                var kGrid = src.TableCount;
                var grids = alloc<RuleGrid>(kGrid);
                var gt=0u;
                var gr=0u;
                for(var i=0; i<kGrid; i++)
                {
                    ref readonly var cTable = ref src[i];
                    ref readonly var sig = ref cTable.Sig;
                    var kCol = cols(cTable);
                    var kRow = cTable.RowCount;
                    var kCells = kRow*kCol;
                    var gRowCols = alloc<Index<GridCol>>(kRow);
                    seek(grids,i) = grid(sig, (ushort)kRow, (byte)kCol, alloc<GridCell>(kCells));
                    ref readonly var gCells = ref skip(grids,i).Cells;
                    for(ushort j=0,gc=0; j<kRow; j++)
                    {
                        ref readonly var cRow = ref cTable[j];
                        seek(gRowCols, j) = alloc<GridCol>(cRow.CellCount);

                        for(var k=0; k<cRow.CellCount; k++, gc++)
                        {
                            ref readonly var cell = ref cRow[k];
                            gCells[gc] = GridCell.from(cell);
                            gRowCols[j][k] = gCells[gc].Def;
                        }
                    }
                }
                return grids;
            }
        }
    }
}