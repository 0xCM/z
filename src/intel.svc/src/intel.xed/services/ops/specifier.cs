//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;
using static XedRender;

partial class Xed
{
    public static string specifier(in OpSpec src)
    {
        const string Pattern = "/{0}";
        var dst = text.buffer();
        dst.AppendFormat("{0}", src.Index);
        dst.AppendFormat(Pattern, format(src.Name));
        dst.AppendFormat(Pattern, format(src.Action));
        dst.AppendFormat(Pattern, format(src.WidthCode));
        dst.AppendFormat(Pattern, format(src.Visibility));
        dst.AppendFormat(Pattern, format(src.OpType));
        if(src.Rule.IsNonEmpty)
            dst.AppendFormat(Pattern, src.Rule.Name.ToString().ToUpper());
        else if(src.ElementType.IsNumber)
            dst.AppendFormat(Pattern, src.ElementType);

        return dst.Emit();
    }
}

