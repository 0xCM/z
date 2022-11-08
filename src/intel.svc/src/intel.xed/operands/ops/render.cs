//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;
    using static XedFields;

    partial class XedOps
    {
        public static void render(Index<OpSpec> src, ITextEmitter dst)
        {
            dst.AppendLineFormat(FieldRender.Columns, "Operands", EmptyString);
            dst.AppendLine(RpOps.PageBreak80);
            for(var i=0; i<src.Count; i++)
                dst.AppendLine(src[i].Format());
        }
    }
}