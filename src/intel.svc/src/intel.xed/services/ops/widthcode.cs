//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;

partial class Xed
{
    [MethodImpl(Inline), Op]
    public static bool widthcode(in PatternOp src, out WidthCode dst)
    {
        var result = XedPatterns.first(src.Attribs, OpAttribKind.Width, out var attrib);
        if(result)
            dst= attrib.ToWidthCode();
        else
            dst = WidthCode.INVALID;;
        return result;
    }
}
