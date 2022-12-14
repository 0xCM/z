//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedDisasm;
    using static XedRules;
    using static XedFields;
    using static XedDisasmModels;

    partial class AsmCoreCmd
    {
        [CmdOp("xed/disasm/check")]
        Outcome DisasmCheck(CmdArgs args)
        {
            var context = ProjectContext();
            var files = XedDisasm.datafiles(context);
            iter(files, file => Write($"Loaded {file.Source}"));
            iter(files, file => Check(file),true);
            return true;
        }

        void Check(in DataFile src)
        {
            var context = ProjectContext();
            var project = context.Project;
            var states = src.ParseStates();
            var render = FieldRender.create();
            Write($"Parsed {states.Count} instructions from {src.Source}");
            for(var i=0; i<states.Count; i++)
            {
                ref readonly var state = ref states[i];
                var kind = FieldKind.MODE;
                if(state.Field(kind, out var value))
                {
                    Write(string.Format("{0}:{1}", kind, render[kind]((ushort)value.Data)));
                    break;
                }
            }
        }
    }
}