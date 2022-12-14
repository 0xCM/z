//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using System.Linq;

    class EcmaCmd : AppCmdService<EcmaCmd>
    {
        Ecma Ecma => Wf.Ecma();

        EcmaEmitter EcmaEmitter => Wf.EcmaEmitter();

        ApiMd ApiMd => Wf.ApiMd();

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
        {            
            ApiMd.Emitter().Emit(ModuleArchives.parts(), AppDb.ApiTargets());         
        }

        [CmdOp("ecma/emit")]
        void EcmaEmit()
        {
            var src = ModuleArchives.parts();
            exec(true,
                () => EcmaEmitter.EmitLocatedMetadata(src, AppDb.ApiTargets("ecma/hex").Delete(), 64),
                () => EcmaEmitter.EmitAssemblyRefs(src, AppDb.ApiTargets("ecma").Delete()),
                () => EcmaEmitter.EmitStrings(src, AppDb.ApiTargets("ecma/strings").Delete()),
                () => EcmaEmitter.EmitRowStats(src, AppDb.ApiTargets("ecma").Table<EcmaRowStats>()),
                () => EcmaEmitter.EmitMsilMetadata(src, AppDb.ApiTargets("ecma/msil.dat").Delete()),
                () => EcmaEmitter.EmitBlobs(src, AppDb.ApiTargets("ecma/blobs").Delete()),
                () => EcmaEmitter.EmitMetadumps(src, Channel, AppDb.ApiTargets("ecma/dumps").Delete()),
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
            => EcmaEmitter.EmitMetadumps(ApiMd.Parts, Channel, AppDb.ApiTargets("ecma/dumps"));

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

        [CmdOp("api/emit/corelib")]
        void EmitCorLib()
        {
            var src = Clr.corlib();
            var reader = EcmaReader.create(src);
            var blobs = reader.ReadBlobs();
            for(var i=0; i<blobs.Length; i++)
            {
                ref readonly var blob = ref skip(blobs,i);
                Write(string.Format("{0,-8} | {1,-8} | {2,-8}", blob.Seq, blob.Offset, blob.DataSize));
            }
        }
    }
}