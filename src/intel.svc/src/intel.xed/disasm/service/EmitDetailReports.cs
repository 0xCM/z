//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedDisasm;

    partial class XedDisasm
    {
        public void EmitDetailReport(ProjectContext context, XedDisasmDoc doc)
        {
            var target = XedPaths.DisasmDetailPath(context.Project.Name, doc.DataSource);
            var dst = text.emitter();
            XedDisasmRender.render(doc.DetailBlocks, dst);
            var emitting = Channel.EmittingFile(target);
            using var emitter = target.AsciEmitter();
            emitter.Write(dst.Emit());
            Channel.EmittedFile(emitting, doc.DetailBlocks.Count);
        }
    }
}