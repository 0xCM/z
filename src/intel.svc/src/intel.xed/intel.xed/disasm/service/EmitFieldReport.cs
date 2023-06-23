//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedDisasm;

    partial class XedDisasm
    {
        public void EmitFieldReport(ProjectContext context, XedDisasmDoc src)
            => EmitFieldReport(context, src.Detail);

        void EmitFieldReport(ProjectContext context, XedDisasmDetail src)
        {
            var emitter = new FieldEmitter();
            var dst = text.emitter();
            var count = emitter.EmitFields(src, dst);
            Channel.FileEmit(dst.Emit(), count, XedPaths.DisasmFieldsPath(context.Project.Name, src.Source));
        }
    }
}