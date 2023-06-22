//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedDisasmModels;

    partial class XedDisasm
    {
        internal class DisasmRender
        {
            public const string OpDetailPattern = "{0,-4} | {1,-8} | {2,-24} | {3,-10} | {4,-12} | {5,-12} | {6,-12} | {7,-12}";

            public static string[] OpColPatterns = new string[]{"Op{0}", "Op{0}Name", "Op{0}Val", "Op{0}Action", "Op{0}Vis", "Op{0}Width", "Op{0}WKind", "Op{0}Selector"};

            public static void render(Index<DisasmDetailBlock> src, ITextEmitter dst, bool header = true)
            {
                var formatter = CsvTables.formatter<DisasmDetailBlockRow>(DisasmDetailBlockRow.RenderWidths);
                if(header)
                    dst.AppendLine(FormatDetailHeader(formatter));

                for(var i=0; i<src.Count; i++)
                    render(formatter, src[i].DetailRow, dst);
            }

            public static string FormatDetailHeader(ICsvFormatter<DisasmDetailBlockRow> formatter)
            {
                var headerBase = formatter.FormatHeader();
                var j = text.lastindex(headerBase, Chars.Pipe);
                headerBase = text.left(headerBase,j);
                var opheader = text.buffer();
                for(var k=0; k<6; k++)
                {
                    opheader.Append("| ");
                    opheader.Append(DisasmRender.OpDetailHeader(k));
                }

                return string.Format("{0}{1}", headerBase, opheader.Emit());
            }

            public static string format(in DisasmBlock src)
            {
                var dst = text.emitter();
                var count = src.Lines.Count;
                for(var i=0; i<count; i++)
                {
                    ref readonly var line = ref src.Lines[i];
                    if(i != count - 1)
                        dst.AppendLine(line.Content);
                    else
                        dst.Append(line.Content);
                }
                return dst.Emit();
            }

            public static void render(ICsvFormatter<DisasmDetailBlockRow> formatter, in DisasmDetailBlockRow src, ITextEmitter dst)
                => dst.AppendLine(formatter.Format(src));

            public static string OpDetailHeader(int index)
                => string.Format(OpDetailPattern, OpColPatterns.Select(x => string.Format(x, index)));

            public static void render(in OpDetails ops, ITextEmitter dst)
                => XedOps.render(ops.Map(x => x.Spec), dst);
        }
    }
}