//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedOps
    {
        [MethodImpl(Inline), Op]
        public static bool scale(in PatternOp src, out MemoryScale dst)
        {
            var result = XedPatterns.first(src.Attribs, OpAttribKind.Scale, out var attrib);
            if(result)
                dst = attrib.ToScale();
            else
                dst = default;
            return result;
        }
    }
}