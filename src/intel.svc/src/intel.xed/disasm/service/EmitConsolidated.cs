//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static XedDisasm;
    using static XedRules;
    using static XedDisasmModels;

    partial class XedDisasmSvc
    {
        void EmitConsolidated(ProjectContext context, Index<DisasmDoc> src)
        {
            var summaries = sys.bag<XedDisasmRow>();
            var details = sys.bag<DisasmDetailBlock>();
            iter(src, pair =>{
                iter(pair.Summary.Rows, r => summaries.Add(r));
                iter(pair.Detail.Blocks, b => details.Add(b));
            });

            exec(PllExec,
                () => EmitOpClasses(context, src),
                () => EmitConsolidated(context, details.ToArray()),
                () => EmitConsolidated(context, summaries.ToArray()));
        }

        void EmitOpClasses(ProjectContext context, Index<DisasmDoc> src)
        {
            var target = EtlContext.table<InstOpClass>(context.Project.Name, disasm);
            Channel.TableEmit(opclasses(src).View, target);
        }

        void EmitConsolidated(ProjectContext context, Index<DisasmDetailBlock> src)
        {
            var target = EtlContext.table<DisasmDetailBlockRow>(context.Project.Name);
            var buffer = text.buffer();
            DisasmRender.render(resequence(src), buffer);
            var emitting = Channel.EmittingFile(target);
            using var emitter = target.AsciEmitter();
            emitter.Write(buffer.Emit());
            Channel.EmittedFile(emitting, src.Count);
        }

        void EmitConsolidated(ProjectContext context, Index<XedDisasmRow> src)
            => Channel.TableEmit(resequence(src), EtlContext.table<XedDisasmRow>(context.Project.Name));
    }
}