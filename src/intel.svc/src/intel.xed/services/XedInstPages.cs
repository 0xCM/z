//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using System.Linq;

using Asm;

using static sys;
using static XedModels;
using static XedInstRender;

public class XedInstPages
{
    public static XedInstPages create()
        => new ();

    public string Format(InstPattern pattern)
        => page(pattern);

    const string InstSep = RP.PageBreak160 + RP.PageBreak20;

    public static string page(InstPattern pattern)
    {
        var emitter = text.emitter();
        emitter.AppendLine(header(pattern));
        emitter.AppendLineFormat(LabelPattern, nameof(pattern.Category), pattern.Category);
        emitter.AppendLineFormat(LabelPattern, "Layout", pattern.Layout.Format());
        emitter.AppendLineFormat(LabelPattern, "Expressions", pattern.Expr.Format());

        emitter.AppendLineFormat(LabelPattern, nameof(pattern.Mode), AsmRender.format(pattern.Mode));
        emitter.AppendLineFormat(LabelPattern, nameof(pattern.OpCode), pattern.OpCode);
        if(pattern.InstForm.IsNonEmpty)
            emitter.AppendLineFormat(LabelPattern, nameof(pattern.InstForm), pattern.InstForm);

        if(pattern.Attributes.IsNonEmpty)
            emitter.AppendLineFormat(LabelPattern, nameof(pattern.Attributes), XedRender.format(pattern.Attributes, false, Chars.Space));

        if(pattern.Effects.IsNonEmpty)
            emitter.AppendLineFormat(LabelPattern, nameof(pattern.Effects), XedRender.format(pattern.Effects, false, Chars.Space));

        Index<string> buffer = alloc<string>(128);
        var fcount = XedInstRender.fields(pattern, buffer);
        for(var k=0; k<fcount;k++)
            emitter.AppendLine(buffer[k]);

        buffer.Clear();

        var opscount = XedInstRender.operands(pattern, buffer);
        for(var k=0; k<opscount;k++)
            emitter.AppendLine(buffer[k]);

        emitter.AppendLine(InstSep);

        return emitter.Emit();
    }

    // static InstIsaFormat format(InstIsa isa, Index<InstPattern> src)
    // {
    //     var counter=0u;
    //     var dst = text.emitter();
    //     for(var i=0; i<src.Count; i++)
    //         dst.Append(page(src[i]));
    //     return new (isa, src, dst.Emit(), counter);
    // }

    static string header(InstPattern src)
        => string.Format("{0,-18}{1,-18}{2}", src.InstClass, src.Isa, src.InstForm);
}
