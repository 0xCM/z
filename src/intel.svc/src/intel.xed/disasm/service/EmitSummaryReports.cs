//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedDisasmModels;

    partial class XedDisasmSvc
    {
        public void EmitSummaryReport(ProjectContext context, DisasmDoc doc)
        {
            var outdir = FolderPath.Empty;
            ref readonly var summary = ref doc.Summary;
            ref readonly var origin = ref summary.Origin;
            Channel.TableEmit(summary.Rows, outdir + origin.Path.FileName.WithoutExtension + FS.ext("xed.disasm.summary.csv"));
        }
    }
}