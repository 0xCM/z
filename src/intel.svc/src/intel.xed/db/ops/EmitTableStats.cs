//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using static XedRules;

    partial class XedDb
    {
        public void EmitTableStats(CellTables src)
        {
            const string RulePattern = "{0:D2} | {1,-12} | {2,-8} | {3,-32} | ";
            const string FieldPattern = "{0,-12} {1,-24}";
            var grids = XedGrids.grids(src);
            var stats = alloc<XedTableStats>(src.TableCount);
            for(var i=0u; i<src.TableCount; i++)
            {
                var rows = grids.Rows(i);
                ref readonly var rule = ref grids[i].Rule;

                var pw = 0u;
                var aw = 0u;
                var mpw = 0u;
                var maw = 0u;
                var mcc = 0u;
                var cc = z16;

                var widths = rows.Select(x => x.Size());
                for(var j=z16; j<rows.Count; j++)
                {
                    ref readonly var row = ref rows[j];
                    ref readonly var width = ref widths[j];

                    if(row.ColCount > mcc)
                        mcc = row.ColCount;
                    if(width.PackedWidth > mpw)
                        mpw = width.PackedWidth;
                    if(width.NativeWidth> maw)
                        maw = width.NativeWidth;

                    pw += width.PackedWidth;
                    aw += width.NativeWidth;
                    cc += row.ColCount;
                }

                seek(stats,i) = new XedTableStats(i, rule, new DataSize(pw, aw), new DataSize(mpw,maw),(ushort)rows.Count, cc, (byte)mcc);
            }

            Channel.TableEmit(stats, XedPaths.DbTable<XedTableStats>(), TextEncodingKind.Asci);
        }
    }
}