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
        public static bool action(in PatternOp src, out OpAction dst)
        {
            var result = XedPatterns.first(src.Attribs, OpAttribKind.Action, out var attrib);
            if(result)
                dst = attrib.ToAction();
            else
                dst = default;

            return result;
        }
    }
}