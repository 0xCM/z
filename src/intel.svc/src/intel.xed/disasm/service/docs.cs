//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class XedDisasm
    {
        public static Index<XedDisasmDoc> docs(ProjectContext context, bool pll = true)
        {
            var dst = sys.bag<XedDisasmDoc>();
            iter(sources(context), src => dst.Add(doc(context,src)), pll);
            return dst.Index();
        }

        public static XedDisasmDoc doc(ProjectContext context, in FileRef src)
        {
            var summary = XedDisasm.summary(context, datafile(context, src));
            return new XedDisasmDoc(summary, detail(summary));
        }
    }
}