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
    [MethodImpl(Inline)]
    public static GridCell cell(in RuleCell src)
        => new (src.Key, ColType.field(src.Field), src.Size, src.Value);

    public static Index<GridCell> cells(in CellRow src)
    {
        var count = src.CellCount;
        var dst = alloc<GridCell>(count);
        for(var i=0; i< count; i++)
            seek(dst,i) = cell(src[i]);
        return dst;
    }

    public static byte cols(in CellTable src)
        => (byte)src.Rows.Select(row => cells(row).Count).Storage.Max();
}