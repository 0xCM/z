//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static XedRules;
using static XedFields;

partial class XedDisasmCmd : WfAppCmd<XedDisasmCmd>
{
    XedRuntime XedRuntime => Wf.XedRuntime();

    public void Etl(IProject project)
    {
        var context = ApiCmd.context(project);
        XedRuntime.Disasm.Collect(context);
    }

    [CmdOp("xed/disasm/files")]
    void DataFiles(CmdArgs args)
    {
        var src = FS.archive(args[0]);
        var files = XedDisasm.datafiles(src);
        iter(files, file => {
            var path = file.Source;
            Channel.Row(path.ToUri());
            var states = file.ParseStates();
            for(var i=0; i< states.Count; i++)
            {
                ref readonly var state = ref states[i];
                Channel.Row(state.Asm);
                var ops = state.Ops;
                for(var j=0; j<ops.Count; j++)
                {
                    ref readonly var op = ref ops[j];
                    Channel.Row(op.Format());
                }
            }
            
            
        });

    }
    [CmdOp("xed/disasm/check")]
    Outcome DisasmCheck(CmdArgs args)
    {
        var src = FS.archive(args[0]);
        var files = XedDisasm.datafiles(src);
        iter(files, file => Write($"Loaded {file.Source}"));
        iter(files, file => Check(file),true);
        return true;
    }

    void Check(in XedDisasmFile src)
    {
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