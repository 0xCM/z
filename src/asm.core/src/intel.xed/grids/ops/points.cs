//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;

    partial class XedGrids
    {
        // [MethodImpl(Inline), Op]
        // public static Grid<ByteBlock32> points(in CellTable src)
        // {
        //     var count = src.CellCount;
        //     var m=0u;
        //     var points = alloc<Point<byte>>(count);
        //     var cells = alloc<RuleCell>(count);
        //     var dst = ByteBlock32.Empty;
        //     for(var j=z8; j<src.RowCount; j++)
        //     {
        //         for(var k=z8; k<src[j].CellCount; k++,m++)
        //         {
        //             ref readonly var cell = ref src[j][k];
        //             seek(points,m) = new (j,k);
        //             seek(cells,m) = src[j][k];
        //         }
        //     }

        //     return new Grid<ByteBlock32>((byte)src.RowCount, (byte)src.RowCount, dst);
        // }
    }
}