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
        public static Index<XedDisasmDoc> docs(IDbArchive src, bool pll = true)
        {
            var dst = sys.bag<XedDisasmDoc>();
            iter(sources(src), path => dst.Add(doc(path)), pll);
            return dst.Index();
        }

        public static XedDisasmDoc doc(FilePath src)
        {
            var summary = XedDisasm.summary(datafile(src));
            return new XedDisasmDoc(summary, detail(summary));
        }
    }
}