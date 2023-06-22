//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedGrids
    {
        public static byte cols(in CellTable src)
            => (byte)src.Rows.Select(row => XedGrids.cells(row).Count).Storage.Max();
    }
}