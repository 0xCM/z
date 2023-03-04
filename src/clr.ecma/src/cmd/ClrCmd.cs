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

        IDbArchive DataTarget => Env.cd().ToArchive().Scoped(".data");

        DataAnalyzer Analyzer => Wf.Analyzer();

        [CmdOp("archive/modules")]
        void EmitModuleIndex(CmdArgs args)
        {
            var src = Archives.modules(FS.dir(args[0])).Members();
            iter(src, m => Channel.Row(m));

        }   

        [CmdOp("clr/refs")]
        void EmitModuleRefs(CmdArgs args)
        {
            var dir = FS.dir(args[0]);
            var src = Archives.modules(dir).Assemblies();
            var dst = bag<AssemblyRef>();
            iter(src, client => iter(Ecma.refs(client), c => dst.Add(c)), true);
            var sorted = dst.Array().Sort();
            var emitter = text.emitter();
            iter(sorted, f => emitter.AppendLineFormat("{0}"));

            // var refs = EcmaReader.refs(src).ToSeq().Sort();
            // var name = $"{Archives.identifier(dir)}.assembly-refs";
            // Channel.TableEmit(refs, DataTarget.Path(name, FileKind.Csv));            
        }   

        [CmdOp("clr/types")]
        void ListTypes(CmdArgs args)
        {
            var dir = FS.dir(args[0]);
            var src = Archives.modules(dir).Assemblies();
            ApiMd.Emitter(Archives.archive(DataTarget.Root)).EmitTypeLists(src);
        }

        [CmdOp("clr/dump")]
        void EcmaEmitMetaDumps(CmdArgs args)
            => EcmaEmitter.EmitMetadumps(FS.dir(args[0]).DbArchive(), true, FS.dir(args[1]).DbArchive());

        
        [CmdOp("analyze")]
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
                using var file = EcmaFile.open(a.Path);
                

            });


        }
    }
}
