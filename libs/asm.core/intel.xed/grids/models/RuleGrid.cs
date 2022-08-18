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
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly struct RuleGrid
        {
            public readonly RuleSig Rule;

            public readonly ushort RowCount;

            public readonly byte ColCount;

            public readonly Index<GridCell> Cells;

            public readonly ushort CellCount;

            public readonly FS.FileUri TablePath;

            [MethodImpl(Inline)]
            public RuleGrid(RuleSig sig, ushort rows, byte cols, Index<GridCell> cells)
            {
                Rule = sig;
                RowCount = rows;
                ColCount = cols;
                Cells = cells;
                CellCount = Require.equal((ushort)(rows*cols), (ushort)cells.Count);
                TablePath = XedPaths.Service.CheckedRulePage(sig);
            }

            public string Format()
            {
                var dst = text.buffer();
                render(this,dst);
                return dst.Emit();
            }

            public override string ToString()
                => Format();
        }
    }
}