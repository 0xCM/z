//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class ClrSvc : WfSvc<ClrSvc>
    {
        EcmaEmitter EcmaEmitter => Wf.EcmaEmitter();

        public Task<ExecToken> EmitModuleRefs(FolderPath src)
        {
            ExecToken impl()
            {
                var running = Channel.Running();
                var modules = Archives.modules(src);
                

                return Channel.Ran(running);
            }

            return start(impl);
        }
    }

    class ClrCmd : WfAppCmd<ClrCmd>
    {
        EcmaEmitter EcmaEmitter => Wf.EcmaEmitter();

        ApiMd ApiMd => Wf.ApiMd();

        ClrSvc ClrSvc => Wf.ClrSvc();

        IEnvDb DataTarget => AppSettings.EnvDb();

        DataAnalyzer Analyzer => Wf.Analyzer();


        [CmdOp("clr/types")]
        void ListTypes(CmdArgs args)
        {
            var dir = FS.dir(args[0]);
            var src = Archives.modules(dir).Assemblies();
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
            iter(src.Assemblies(), a => {                
                using var file = Ecma.file(a.Path);                
            });
        }
    }
}
