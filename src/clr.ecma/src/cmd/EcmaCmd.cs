//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static sys;

    class EcmaCmd : WfAppCmd<EcmaCmd>
    {
        Ecma Ecma => Wf.Ecma();

        EcmaEmitter EcmaEmitter => Wf.EcmaEmitter();

        ApiMd ApiMd => Wf.ApiMd();

        void DescribeHeaps()
        {
            var heaps = Ecma.strings(ApiMd.Parts);
            var count = heaps.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var heap = ref heaps[i];
                var data = heap.Data;
                var size = heap.Size;
                var dst = text.emitter();
                dst.Append(heap.BaseAddress.Format());
                for(var j=0; j<size; j++)
                    dst.AppendFormat(" {0:X2}", skip(data,j));
                Write(dst.Emit());
            }
        }

        public static void exec(IWfChannel channel, CatalogAssemblies cmd)
        {
            var src = from file in cmd.Source.DbArchive().Enumerate("*.dll")
                        where EcmaReader.valid(file)
                        select file;            
            var dst = cmd.Target.DbArchive();
            var formatter = Tables.formatter<EcmaRowStats>();
            iter(src, path => {
                if(EcmaReader.file(path, out var file))
                {
                    try
                    {
                        var reader = EcmaReader.create(file);
                        var stats = EcmaReader.stats(reader);
                        iter(stats, row => channel.Row(formatter.Format(row)));
                    }
                    finally
                    {
                        file.Dispose();
                    }
                }
            });      
        }        
        
        void RunCliJobs()
        {
            var root = Env.var(EnvVarKind.Process, EnvTokens.DOTNET_ROOT, FS.dir).Value;
            var src = root.Files(FileKind.Dll).Map(x => new FileUri(x.Format())).ToSeq();
            var name = CmdId.identify<EmitEcmaDatasets>().Format();
            var ts = timestamp();
            var dst = AppDb.Jobs(CmdId.identify<EmitEcmaDatasets>().Format()).Path($"{name}.{ts}.jobs", FileKind.Json);
            var job = new EmitEcmaDatasets();
            job.JobId = ts;
            job.Sources = src;
            job.Targets = AppDb.DbTargets("tools/jobs").Folder(CmdId.identify<EmitEcmaDatasets>().Format());
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

        static IApiPack Dst
            => ApiPacks.create();

        [CmdOp("api/emit")]
        void ApiEmit()
            => ApiMd.Emitter().Emit(ApiModules.parts(), AppDb.ApiTargets());

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

        [CmdOp("ecma/catalog")]
        void EmitEcmaCatalog(CmdArgs args)
        {
            var cmd = new CatalogAssemblies();
            cmd.Source = FS.dir(args[0]);
            exec(Channel, cmd);        
        }

        [CmdOp("ecma/emit")]
        void EcmaEmitMetaDumps(CmdArgs args)
            => EcmaEmitter.EmitMetadumps(args);

        [CmdOp("ecma/list")]
        void EcmaList(CmdArgs args)
            => EcmaEmitter.EmitList(args);

        [CmdOp("ecma/emit/parts")]
        void EmitPartEcma()
        {
            var src = ApiModules.parts();
            EcmaEmitter.EmitCatalogs(src);
        }

        [CmdOp("ecma/emit/hex")]
        void EmitApiHex()
            => EcmaEmitter.EmitLocatedMetadata(ApiModules.parts(), AppDb.ApiTargets("ecma/hex"), 64);

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
                    EmitMetadumps(ListArchives.load(Channel, src, parse));
                else
                    EcmaEmitter.EmitMetadump(src, EcmaArchive(src));
            }
        }
    }
}