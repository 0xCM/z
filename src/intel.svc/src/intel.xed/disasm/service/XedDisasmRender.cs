//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedRules;

class XedDisasmRender
{
    public const string OpDetailPattern = " {0,-12} | {1,-12} | {2,-24} | {3,-16} | {4,-16} | {5,-16} | {6,-16} | {7,-48}";

    public static string[] OpColPatterns = new string[]{
        "Op[{0}].Id", 
        "Op[{0}].Name", 
        "Op[{0}].Val", 
        "Op[{0}].Action", 
        "Op[{0}].Vis",
        "Op[{0}].Width", 
        "Op[{0}].WKind", 
        "Op[{0}].Specifier"
        };

    public static void render(Index<XedDisasmDetailBlock> src, ITextEmitter dst, bool header = true)
    {
        var formatter = CsvTables.formatter<XedDisasmDetailRow>(XedDisasmDetailRow.RenderWidths);
        if(header)
            dst.AppendLine(FormatDetailHeader(formatter));

        for(var i=0; i<src.Count; i++)
            dst.AppendLine(formatter.Format(src[i].DetailRow));
    }

    public static string FormatDetailHeader(ICsvFormatter<XedDisasmDetailRow> formatter)
    {
        var headerBase = formatter.FormatHeader();
        var j = text.lastindex(headerBase, Chars.Pipe);
        headerBase = text.left(headerBase,j);
        var opheader = text.buffer();
        for(var k=0; k<6; k++)
        {
            opheader.Append("| ");
            opheader.Append(OpDetailHeader(k));
        }

        return string.Format("{0}{1}", headerBase, opheader.Emit());
    }

    public static string format(in XedDisasmBlock src)
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

    public static string OpDetailHeader(int index)
        => string.Format(OpDetailPattern, OpColPatterns.Select(x => string.Format(x, index)));

    public static void render(in OpDetails ops, ITextEmitter dst)
        => XedRender.render(ops.Map(x => x.Spec), dst);
}
