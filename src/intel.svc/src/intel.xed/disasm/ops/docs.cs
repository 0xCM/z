//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using System.Linq;

    partial class XedDisasm
    {
        public static ParallelQuery<XedDisasmDoc> docs(IDbArchive src)
            => from path in sources(src)
                select doc(path);

        public static XedDisasmDoc doc(FilePath src)
        {
            var summary = XedDisasm.summary(datafile(src));
            return new XedDisasmDoc(summary, detail(summary));
        }
    }
}