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
    public static bool modifier(in PatternOp src, out OpModifier dst)
    {
        if(XedPatterns.first(src.Attribs, OpAttribKind.Modifier, out var attrib))
            dst = attrib.ToModifier();
        else
            dst = default;
        return true;
    }
}
