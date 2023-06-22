//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static XedDisasmModels;

    partial class XedDisasm
    {
        public static Index<DisasmDoc> docs(ProjectContext context, bool pll = true)
        {
            var dst = sys.bag<DisasmDoc>();
            iter(sources(context), src => dst.Add(doc(context,src)), pll);
            return dst.Index();
        }

        public static DisasmDoc doc(ProjectContext context, in FileRef src)
        {
            var summary = XedDisasm.summary(context, datafile(context, src));
            return new DisasmDoc(summary, detail(summary));
        }
    }
}