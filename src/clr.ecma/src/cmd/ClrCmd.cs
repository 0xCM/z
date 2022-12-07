//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static sys;
    using static Env;

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
            var refs = EcmaReader.refs(src).ToSeq().Sort();
            var name = $"{Archives.identifier(dir)}.assembly-refs";
            Channel.TableEmit(refs, DataTarget.Path(name, FileKind.Csv));            
        }   


        [CmdOp("clr/types")]
        void ListTypes(CmdArgs args)
            => ApiMd.Emitter(Archives.archive(DataTarget.Root)).EmitTypeLists(AssemblyFiles.managed(FS.dir(args[0])));


        [CmdOp("clr/dump")]
        void EcmaEmitMetaDumps(CmdArgs args)
            => EcmaEmitter.EmitMetadumps(FS.dir(args[0]), false, DataTarget.Scoped("metdumps"));
    }
}
