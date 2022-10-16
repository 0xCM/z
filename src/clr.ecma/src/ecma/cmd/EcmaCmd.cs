//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static sys;

    class EcmaCmd : AppCmdService<EcmaCmd>
    {
        Ecma Ecma => Wf.Ecma();

        EcmaEmitter EcmaEmitter => Wf.EcmaEmitter();

        ApiMd ApiMd => Wf.ApiMd();

        void RunCliJobs()
        {
            var root = Env.var(EnvVarKind.Process, SettingNames.DOTNET_ROOT, FS.dir).Value;
            var src = root.Files(FileKind.Dll).Map(x => new FileUri(x.Format())).ToSeq();
            var name = Cmd.identify<EmitEcmaDatasets>().Format();
            var ts = timestamp();
            var dst = AppDb.Jobs(Cmd.identify<EmitEcmaDatasets>().Format()).Path($"{name}.{ts}.jobs", FileKind.Json);
            var job = new EmitEcmaDatasets();
            job.JobId = ts;
            job.Sources = src;
            job.Targets = AppDb.DbTargets("tools/jobs").Folder(Cmd.identify<EmitEcmaDatasets>().Format());
            job.Settings = EcmaEmissionSettings.Default;
            
            var data = JsonData.serialize(job);
            FileEmit(data, dst);
        }

        public void EmitCatalog(IApiCatalog src)
        {
            var dst = ApiPacks.create();
            ApiMd.Emitter().Emit(src,dst);
            EcmaEmitter.Emit(src, EcmaEmissionSettings.Default, dst);
        }

        public static unsafe PEReader PeReader(MemorySeg src)
            => new PEReader(src.BaseAddress.Pointer<byte>(), src.Size);

        static IApiPack Dst
            => ApiPacks.create();

        [CmdOp("api/emit")]
        void ApiEmit()
            => ApiMd.Emitter().Emit(ModuleArchives.parts(), AppDb.ApiTargets());

        static void EcmaEmit(IWfChannel channel, FilePath src, IDbArchive dst)
        {
            try
            {
                var name = src.FileName.WithoutExtension.Name.Format();
                channel.Write($"{src} -> ${dst.Root}/{name}");
            }
            catch(Exception e)
            {
                channel.Error(e);
            }
        }

        void EcmaEmit(Files src)
        {
            iter(src, path => EcmaEmit(Channel, path, AppDb.DbTargets("ecma/datasets")));
        }

        [CmdOp("ecma/emit")]
        void EcmaEmit(CmdArgs args)
        {
            var src = new ModuleArchive(FS.dir(args[0]));            
            var dlls = src.ManagedDll().Where(path => !path.Path.Contains(".resources.dll")).Select(x => x.Path);
            var exe = src.ManagedExe().Select(x => x.Path);
            EcmaEmitter.EmitMetadumps(Channel, src,AppDb.DbTargets("ecma/datasets"));                     
        }

        [CmdOp("ecma/list")]
        void EcmaList(CmdArgs args)
        {
            var src = FS.dir(args[0]).DbArchive();
            Channel.Write(src.Root);
            iter(src.Enumerate("*.dll"), file =>{
                if(EcmaFile.load(file, out EcmaFile ecma))
                {
                    try
                    {
                        Channel.Write($"{ecma.Uri}");
                    }
                    catch(Exception e)
                    {
                        Channel.Error(e);
                    }
                    finally
                    {
                        ecma.Dispose();
                    }
                }
            });
        }

        [CmdOp("ecma/emit/parts")]
        void EmitPartEcma()
        {
            var src = ModuleArchives.parts();
            exec(true,
                () => EcmaEmitter.EmitLocatedMetadata(src, AppDb.ApiTargets("ecma/hex").Delete(), 64),
                () => EcmaEmitter.EmitAssemblyRefs(src, AppDb.ApiTargets("ecma").Delete()),
                () => EcmaEmitter.EmitStrings(src, AppDb.ApiTargets("ecma/strings").Delete()),
                () => EcmaEmitter.EmitRowStats(src, AppDb.ApiTargets("ecma").Table<EcmaRowStats>()),
                () => EcmaEmitter.EmitMsilMetadata(src, AppDb.ApiTargets("ecma/msil.dat").Delete()),
                () => EcmaEmitter.EmitBlobs(src, AppDb.ApiTargets("ecma/blobs").Delete()),
                () => EcmaEmitter.EmitMetadumps(Channel, src, AppDb.ApiTargets("ecma/dumps").Delete()),
                () => EcmaEmitter.EmitMemberRefs(src, AppDb.ApiTargets("ecma/members.refs").Delete()),
                () => EcmaEmitter.EmitMethodDefs(src, AppDb.ApiTargets("ecma/methods.defs").Delete()),
                () => {}
            );
        }

        [CmdOp("ecma/emit/hex")]
        void EmitApiHex()
            => EcmaEmitter.EmitLocatedMetadata(ModuleArchives.parts(), AppDb.ApiTargets("ecma/hex"), 64);

        [CmdOp("ecma/emit/assembly-refs")]
        void EmitAssmeblyRefs()
            => EcmaEmitter.EmitAssemblyRefs(ApiMd.Parts, AppDb.ApiTargets("ecma"));

        [CmdOp("ecma/emit/method-defs")]
        void EmitMethodDefs()
            => EcmaEmitter.EmitMethodDefs(ApiMd.Parts, AppDb.ApiTargets("ecma/methods.defs").Delete());

        [CmdOp("ecma/emit/member-refs")]
        void EmitMemberRefs()
            => EcmaEmitter.EmitMemberRefs(ApiMd.Parts, AppDb.ApiTargets("ecma/members.refs"));

        [CmdOp("ecma/emit/strings")]
        void EmitStrings()
            => EcmaEmitter.EmitStrings(ApiMd.Parts, AppDb.ApiTargets("ecma/strings"));

        [CmdOp("ecma/emit/stats")]
        void EmitStats()
            => EcmaEmitter.EmitRowStats(ApiMd.Parts, AppDb.ApiTargets("ecma").Table<EcmaRowStats>());

        [CmdOp("ecma/emit/blobs")]
        void EmitBlobs()
            => EcmaEmitter.EmitBlobs(ApiMd.Parts, AppDb.ApiTargets("ecma/blobs"));

        [CmdOp("ecma/emit/msil")]
        void EmitMsil()
        {
            var src = ApiMd.ApiHosts.GroupBy(x => x.Assembly).Map(x => (x.Key,x.Array())).ToDictionary();
            Ecma.EmitMsil(src, AppDb.ApiTargets("ecma/msil"));
        }

        [CmdOp("ecma/emit/msildat")]
        void EmitMsilData()
            => EcmaEmitter.EmitMsilMetadata(ApiMd.Parts, AppDb.ApiTargets("ecma/msil.dat"));

        [CmdOp("ecma/emit/literals")]
        void EmitLiterals()
            => EcmaEmitter.EmitLiterals(Dst);

        [CmdOp("ecma/emit/headers")]
        void EmitHeaders()
            => EcmaEmitter.EmitSectionHeaders(Dst);

        static FilePath EcmaArchive(FilePath src)
            => AppDb.Archive("ecma").Path(src.FileName.WithExtension(FS.ext($"{src.Hash}.txt")));

        void EmitMetadumps(ItemList<uint,FilePath> src)        
        {
            iter(src, file => {
                if(file.Value.IsNot(FS.ext("resources.dll")))
                {
                    EcmaEmitter.EmitMetadump(file.Value, EcmaArchive(file.Value));
                    var path = EcmaArchive(file.Value);                    
                    }
                }, PllExec);
        }

        static Outcome<FilePath> parse(string src)
            => FS.path(src);

        [CmdOp("ecma/emit/dumps")]
        void EmitMetaDumps()
            => EcmaEmitter.EmitMetadumps(Channel, ApiMd.Parts, AppDb.ApiTargets("ecma/dumps"));

        [CmdOp("ecma/dump")]
        void EmitCliDump(CmdArgs args)
        {
            foreach(var arg in args)
            {
                var value = arg.Value;
                var src = FS.path(value);
                if(src.Is(FileKind.List))
                    EmitMetadumps(ListArchives.load(src, parse, Emitter));
                else
                    EcmaEmitter.EmitMetadump(src, EcmaArchive(src));
            }
        }
    }
}