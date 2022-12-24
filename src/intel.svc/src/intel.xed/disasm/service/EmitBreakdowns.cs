//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static XedDisasmModels;

    partial class XedDisasmSvc
    {
        public void EmitBreakdowns(ProjectContext context, Index<Document> docs)
            => iter(docs, doc => EmitBreakdowns(context, doc), PllExec);

        public void EmitBreakdowns(ProjectContext context, Document doc)
        {
            exec(PllExec,
                    () => EmitDetailReport(context, doc),
                    () => EmitOpsReport(context, doc),
                    () => EmitChecksReport(context, doc),
                    () => EmitFieldReport(context, doc)
                    );
        }
    }
}