//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public void EmitInstSigs(Index<InstPattern> src)
        {
            const string RenderPattern = "{0,-18} | {1,-6} | {2,-26} | {3}";
            var dst = text.emitter();
            XedSigs.render(CalcInstSigs(src), dst);
            Channel.FileEmit(dst.Emit(), src.Count, XedPaths.InstTarget("patterns.sigs", FileKind.Csv));
        }
   }
}