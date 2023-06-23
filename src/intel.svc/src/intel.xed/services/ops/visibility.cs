//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class Xed
    {
        [MethodImpl(Inline), Op]
        public static bool visibility(in PatternOp src, out Visibility dst)
        {
            if(XedPatterns.first(src.Attribs, OpAttribKind.Visibility, out var attrib))
                dst = attrib.ToVisibility();
            else
                dst = OpVisibility.Explicit;
            return true;
        }
    }
}