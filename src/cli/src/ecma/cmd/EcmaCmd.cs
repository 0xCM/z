//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    class EcmaCmd : AppCmdService<EcmaCmd>
    {
        Ecma Cli => Wf.Ecma();

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

        [CmdOp("ecma/emit/hex")]
        void EmitApiHex()
            => EcmaEmitter.EmitLocatedMetadata(Dst);

        [CmdOp("ecma/emit/refs")]
        void EmitMemberRefs()
            => EcmaEmitter.EmitRefs(AppDb.ApiTargets("ecma/refs"));

        [CmdOp("ecma/emit/strings")]
        void EmitStrings()
            => EcmaEmitter.EmitStrings(Dst);

        [CmdOp("ecma/emit/stats")]
        void EmitStats()
            => EcmaEmitter.EmitRowStats(ApiMd.Parts, AppDb.ApiTargets().Table<EcmaRowStats>());

        [CmdOp("ecma/emit/blobs")]
        void EmitBlobs()
            => EcmaEmitter.EmitBlobs(Dst);

        [CmdOp("ecma/emit/msil")]
        void EmitMsil()
            => Cli.EmitIl(Dst);

        [CmdOp("ecma/emit/ildat")]
        void EmitIlDat()
            => EcmaEmitter.EmitIlDat(Dst);

        // [CmdOp("ecma/emit/fields")]
        // void EmitFields()
        //     => EcmaEmitter.EmitFieldMetadata(Dst);

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
                    
                    }            }, PllExec);
        }

        static Outcome<FilePath> parse(string src)
            => FS.path(src);

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