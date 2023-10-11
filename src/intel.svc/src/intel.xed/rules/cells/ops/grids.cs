//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedRules;
using static sys;

partial struct XedCells
{
    [MethodImpl(Inline), Op]
    public static RuleGrid grid(RuleSig sig, ushort rows, byte cols, GridCell[] cells)
        => new (sig, rows, cols, cells);

    public static RuleGrids grids(CellTables src)
        => src.View.Select(table => grid(table));

    public static RuleGrid grid(in CellTable src)
    {
        var kCol = cols(src);
        var kRow = src.RowCount;
        var dst = alloc<GridCell>(kCol*kRow);
        var k=z8;
        for(var i=0; i<kRow; i++)
        {
            var gcells = cells(src[i]);
            for(var j=0; j<gcells.Count; j++, k++)
                seek(dst, k) = gcells[j];

            for(var j=k; j<kCol; j++, k++)
                seek(dst, k) = GridCell.Empty;
        }
        return grid(src.Sig, (ushort)src.RowCount, kCol, dst);
    }    
}