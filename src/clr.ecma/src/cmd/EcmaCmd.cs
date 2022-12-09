//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static sys;
    using static Env;

    class EcmaCmd : WfAppCmd<EcmaCmd>
    {
        Ecma Ecma => Wf.Ecma();

        EcmaEmitter EcmaEmitter => Wf.EcmaEmitter();

        ApiMd ApiMd => Wf.ApiMd();

        static IApiPack Dst
            => ApiPacks.create();

        [CmdOp("ecma/list")]
        void EcmaList(CmdArgs args)
            => EcmaEmitter.EmitList(args);

        public static ReadOnlySeq<Assembly> Parts(FolderPath src)
        {
            var modules = Archives.modules(src,false).Members().Where(x => FS.managed(x.Path) && !x.Path.FileName().Contains("System.Private.CoreLib"));
            return modules.Where(m => m.Path.FileName().StartsWith("z0.")).Map(x => Assembly.LoadFile(x.Path.ToFilePath().Format()));
        }

        [CmdOp("api/parts")]
        void ApiAssemblies()
        {

            var root = FS.path(controller().Location).FolderPath;
            var src  = Parts(root);
            // var src = Archives.modules(root).Members();
            iter(src, a => Write(a.Path()));

        }
        [CmdOp("ecma/emit/parts")]
        void EmitPartEcma()
            => EcmaEmitter.EmitCatalogs(ApiMd.Parts, AppDb.ApiTargets());

        [CmdOp("ecma/emit/hex")]
        void EmitApiHex()
            => EcmaEmitter.EmitLocatedMetadata(ApiMd.Parts, AppDb.ApiTargets("ecma/hex"), 64);

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
            => ApiMd.Emitter(AppDb.ApiTargets()).EmitLiterals(ApiMd.Parts);

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
                var types = reader.ReadTypeDefs();
                iter(types, t => Channel.Write(t.Name));
            });
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

        [CmdOp("pe/info")]
        void ExportPeInfo(CmdArgs args)
        {
            var src = Archives.archive(args[0]);

            var dst = ShellData.Path(FS.file($"{Archives.identifier(src.Root)}.peinfo", FS.ext("records")));
            var flow = Channel.EmittingFile(dst);
            var counter = 0u;
            var type = typeof(FileModuleInfo).GetType().AssemblyQualifiedName;
            using var writer = dst.Writer();
            iter(src.Enumerate(true, FileKind.Exe, FileKind.Dll), path => {                
                using var reader = PeReader.create(path);
                var info = reader.Describe();
                writer.AppendLineFormat("{0,-120} | {1:D5} | {2}", path, counter++, type);
                writer.AppendLine(RP.PageBreak180);
                writer.AppendLine(info);     
                writer.AppendLine();           
            });
            Channel.EmittedFile(flow);
        }
    }
}