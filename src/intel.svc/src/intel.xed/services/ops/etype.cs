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
        public static bool etype(in PatternOp src, out XedModels.ElementType dst)
        {
            var result = XedPatterns.first(src.Attribs, OpAttribKind.ElementType, out var attrib);
            if(result)
                dst = attrib.ToElementType();
            else
                dst = XedModels.ElementType.Empty;

            return result;
        }
    }
}