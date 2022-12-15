//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class XedGrids
    {
        public static void render(RuleGrid src, ITextEmitter dst)
        {
            const string RowRenderPattern = "{0,-3} | {1,-3} | {2,-32} | {3}";

            var k=0;
            var data = src.Cells.View;

            dst.AppendLine(string.Format("{0,-32} {1}", src.Rule.Format(), src.TablePath));
            dst.AppendLine(RP.PageBreak260);
            for(var i=0; i<src.RowCount; i++)
            {
                var offset = i*src.ColCount;
                var cells = slice(data, offset, src.ColCount);
                var count = Require.equal(cells.Length, src.ColCount);
                var nonempty = cells.Where(x => x.Field != 0);
                count = nonempty.Length;
                for(var j=0; j<src.ColCount; j++)
                {
                    ref readonly var cell = ref skip(cells,j);

                    if(j==0)
                    {
                        dst.AppendFormat(RowRenderPattern, cell.Row, src.Rule.TableKind, src.Rule.TableName, cell.Def.Format());

                        continue;
                    }

                    if(cell.IsEmpty)
                        continue;

                    dst.Append(" | ");
                    dst.Append(cell.Def.Format());
                }
                dst.AppendLine();
            }
        }
    }
}