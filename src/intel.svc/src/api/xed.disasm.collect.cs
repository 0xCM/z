//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static XedRules;
using static XedFields;

partial class XedDisasmCmd
{
    [CmdOp("xed/disasm/collect")]
    void Etl(CmdArgs args)
    {
        var src = FS.archive(args[0]);
        var project = new DevProject(src.Root);
        var docs = XedDisasm.docs(project.Root);
        piter(docs, doc => {
            var path = doc.SourcePath;
            var flow = Channel.Running($"Collecting disassembly content from {path.ToUri()}");
            XedDisasm.EmitDetails(project, doc);
            XedDisasm.EmitOps(project, doc);
            XedDisasm.EmitSummaries(project, doc);
            XedDisasm.EmitChecks(project,doc);
            Channel.Ran(flow,$"Collected disassembly content from {path.ToUri()}");
        });

        XedDisasm.Consolidate(project,docs);

        //XedDisasm.Collect(project);

    }

    [CmdOp("xed/disasm/docs")]
    void DataFiles(CmdArgs args)
    {
        var src = FS.archive(args[0]);
        var files = XedDisasm.datafiles(src);
        iter(files, file => {
            var path = file.Source;
            Channel.Row(path.ToUri());
            var states = file.ParseStates();
            // for(var i=0; i< states.Count; i++)
            // {
            //     ref readonly var state = ref states[i];
            //     Channel.Row(state.Asm);
            //     var ops = state.Ops;
            //     for(var j=0; j<ops.Count; j++)
            //     {
            //         ref readonly var op = ref ops[j];
            //         Channel.Row(op.Format());
            //     }
            // }                     
        });
    }
}