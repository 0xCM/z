//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static sys;
    using static Env;

    [Cmd(CmdName)]
    public record class EmitAssemblyList : Command<EmitAssemblyList>
    {
        const string CmdName = "ecma/list";

        public FolderPath Source;


        public FilePath Target;
    }

    partial class EcmaCmd : WfAppCmd<EcmaCmd>
    {
        Ecma Ecma => Wf.Ecma();

        EcmaEmitter EcmaEmitter => Wf.EcmaEmitter();

        ApiMd ApiMd => Wf.ApiMd();

        static IApiPack Dst
            => ApiPacks.create();

        [CmdOp("ecma/emit")]
        void EcmaEmit()
            => EcmaEmitter.Emit(ApiAssemblies.Parts, EcmaEmissionSettings.Default, AppDb.ApiTargets("ecma"));

        [CmdOp("ecma/list")]
        void EcmaList(CmdArgs args)
        {
            var cmd = EmitAssemblyList.Empty;
            cmd.Source = FS.dir(args[0]);
            if(args.Count > 1)
                cmd.Target = FS.path(args[1]);
            else
                cmd.Target = Env.ShellData.Path("assemblies", FileKind.Csv);
            EcmaEmitter.EmitAssemblyList(cmd.Source.DbArchive(), cmd.Target);
        }

        public static ReadOnlySeq<Assembly> Parts(FolderPath src)
        {
            var modules = Archives.modules(src,false).Members().Where(x => FS.managed(x.Path) && !x.Path.FileName.Contains("System.Private.CoreLib"));
            return modules.Where(m => m.Path.FileName.StartsWith("z0.")).Map(x => Assembly.LoadFile(x.Path.Format()));
        }

        [CmdOp("api/parts")]
        void ApiPartList()
        {
            var root = FS.path(controller().Location).FolderPath;
            var src  = Parts(root);
            iter(src, a => Write(a.Path()));
        }

        [CmdOp("api/catalog")]
        void EmitApiCatalog()
        {
            var src = ApiCatalog.catalog();
            var parts = src.Parts;
            var hosts = src.PartHosts();
            var catalogs = src.PartCatalogs;
            var assemblies = src.Assemblies;

            var counter = 0u; 
            iter(parts, part => {
                Channel.Row(string.Format("{0:D6} | {1,-24} | {2,-16} {3}", counter++, part.Owner.GetSimpleName(), part.Owner.AssemblyVersion(), part.Owner.Path()));
            });

            counter=0u;
            iter(hosts, host => {
                Channel.Row(string.Format("{0:D6} | {1,-16} | {2}", counter++, host.Assembly.GetSimpleName(), host.HostUri));
            });            
        }

        [CmdOp("ecma/emit/parts")]
        void EmitPartEcma()
            => EcmaEmitter.EmitCatalogs(ApiAssemblies.Parts, AppDb.ApiTargets());

        [CmdOp("ecma/emit/hex")]
        void EmitApiHex()
            => EcmaEmitter.EmitLocatedMetadata(ApiAssemblies.Parts, AppDb.ApiTargets("ecma/hex"), 64);

        [CmdOp("ecma/emit/assembly-refs")]
        void EmitAssmeblyRefs(CmdArgs args)
            => EcmaEmitter.EmitAssemblyRefs(ApiAssemblies.Parts, AppDb.ApiTargets("ecma"));

        [CmdOp("ecma/emit/method-defs")]
        void EmitMethodDefs(CmdArgs args)
            => EcmaEmitter.EmitMethodDefs(ApiAssemblies.Parts, AppDb.ApiTargets("ecma/methods.defs").Delete());

        [CmdOp("ecma/emit/member-refs")]
        void EmitMemberRefs(CmdArgs args)
            => EcmaEmitter.EmitMemberRefs(ApiAssemblies.Parts, AppDb.ApiTargets("ecma/members.refs"));

        [CmdOp("ecma/emit/strings")]
        void EmitStrings(CmdArgs args)
            => EcmaEmitter.EmitStrings(ApiAssemblies.Parts, AppDb.ApiTargets("ecma/strings"));

        [CmdOp("ecma/emit/stats")]
        void EmitStats(CmdArgs args)
            => EcmaEmitter.EmitRowStats(ApiAssemblies.Parts, AppDb.ApiTargets("ecma").Table<EcmaRowStats>());

        [CmdOp("ecma/emit/blobs")]
        void EmitBlobs(CmdArgs args)
            => EcmaEmitter.EmitBlobs(ApiAssemblies.Parts, AppDb.ApiTargets("ecma/blobs"));

        [CmdOp("ecma/emit/msil")]
        void EmitMsil()
        {
            var src = ApiMd.ApiHosts.GroupBy(x => x.Assembly).Map(x => (x.Key,x.Array())).ToDictionary();
            Ecma.EmitMsil(src, AppDb.ApiTargets("ecma/msil"));
        }

        [CmdOp("ecma/emit/msildat")]
        void EmitMsilData()
            => EcmaEmitter.EmitMsilMetadata(ApiAssemblies.Parts, AppDb.ApiTargets("ecma/msil.dat"));

        [CmdOp("ecma/emit/literals")]
        void EmitLiterals()
            => ApiMd.Emitter(AppDb.ApiTargets()).EmitLiterals(ApiAssemblies.Parts);

        [CmdOp("ecma/emit/headers")]
        void EmitHeaders()
            => EcmaEmitter.EmitSectionHeaders(sys.controller().RuntimeArchive(), Dst);

        [CmdOp("ecma/emit/typedefs")]
        void EmitTypeDefs(CmdArgs args)
        {
            var modules = Archives.modules(FS.dir(args[0])).Assemblies();
            iter(modules, module => {
                using var file = EcmaFile.open(module.Path);
                var reader = EcmaReader.create(file);
                reader.ReadTypeDefs(td => {
                    Channel.Row(td);
                });               
            });
        }

        void Mapped(MappedAssembly src)
        {
            var reader = src.MetadataReader();
            Channel.Row(string.Format("{0,-8} | {1,-16} | {2,-12} | {3,-56} | {4}", src.Index, src.BaseAddress, src.FileSize, src.FileHash, reader.AssemblyName().SimpleName(), FlairKind.StatusData));
        }

        [CmdOp("ecma/md")]
        void EcmaMeta(CmdArgs args)
        {
            using var map = new ModuleMap(Channel, Mapped);
            map.Include(EcmaWokflows.sources());
        }

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
            => EcmaEmitter.EmitMetadumps(Channel, ApiAssemblies.Parts, AppDb.ApiTargets("ecma/dumps"));

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

        [CmdOp("coff/modules")]
        void ExportPeInfo(CmdArgs args)
        {
            var src = Archives.archive(args[0]);
            var dst = ShellData.Path(FS.file($"{Archives.identifier(src.Root)}.modules", FS.ext("records")));
            var modules = bag<CoffModule>();
            PeReader.modules(src,module => {
                modules.Add(module);
            });
            var buffer = text.emitter();
            var context = RenderContext.create(buffer);
            iter(modules, m => {
                buffer.AppendLine(m.ToString());
            });
                        
            Channel.FileEmit(buffer.Emit(), dst);
        }
    }
}