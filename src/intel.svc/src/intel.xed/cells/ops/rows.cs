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
    public static GridRow row(RuleSig rule, ushort row, GridCol[] cols)
        => new (rule, row, cols);

    public static Index<GridRow> rows(RuleSig rule, ushort rows, byte cols, Index<GridCell> src)
    {
        var dst = alloc<GridRow>(rows);
        var k=0u;
        for(var i=z16; i<rows; i++)
        {
            seek(dst, i) = row(rule, i, alloc<GridCol>(cols));
            ref readonly var grow = ref skip(dst,i);
            for(var j=z8; j<grow.ColCount; j++, k++)
                grow.Cols[j] = src[k].Def;
        }
        return dst;
    }    
}