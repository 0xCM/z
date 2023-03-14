//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class ClrSvc : WfSvc<ClrSvc>
    {
    }

    class ClrCmd : WfAppCmd<ClrCmd>
    {
        EcmaEmitter EcmaEmitter => Wf.EcmaEmitter();

        ApiMd ApiMd => Wf.ApiMd();


        IEnvDb DataTarget => AppSettings.EnvDb();

        DataAnalyzer Analyzer => Wf.Analyzer();

        [CmdOp("clr/types")]
        void ListTypes(CmdArgs args)
        {
            var dir = FS.dir(args[0]);
            var src = Archives.modules(dir).AssemblyFiles();
            ApiMd.Emitter(Archives.archive(DataTarget.Scoped("clr"))).EmitTypeLists(src);
        }


        [CmdOp("files/analyze")]
        void Analyze(CmdArgs args)
        {
            var src = FS.dir(args[0]).DbArchive();
            var dst = FS.dir(args[1]).DbArchive();
            Analyzer.Run(src,dst);            
        }

        [CmdOp("ecma/debug")]
        void DebugMethods(CmdArgs args)
        {
            var src = FS.dir(args[0]).DbArchive().Modules();
            iter(src.AssemblyFiles(), a => {                
                using var file = Ecma.file(a.Path);                
            });
        }
    }
}
