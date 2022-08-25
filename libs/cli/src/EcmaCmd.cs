//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;
    using static Algs;

    class EcmaCmd : AppCmdService<EcmaCmd>
    {
        Cli Cli => Wf.Cli();

        CliEmitter CliEmitter => Wf.CliEmitter();

        ApiMd ApiMd => Wf.ApiMd();

        public static unsafe PEReader PeReader(MemorySeg src)
            => new PEReader(src.BaseAddress.Pointer<byte>(), src.Size);

        static IApiPack Dst
            => ApiPacks.create();

        [CmdOp("ecma/emit/hex")]
        void EmitApiHex()
            => CliEmitter.EmitLocatedMetadata(Dst);

        [CmdOp("ecma/emit/refs")]
        void EmitMemberRefs()
            => CliEmitter.EmitRefs(Dst);

        [CmdOp("ecma/emit/strings")]
        void EmitStrings()
            => CliEmitter.EmitStrings(Dst);

        [CmdOp("ecma/emit/stats")]
        void EmitStats()
            => CliEmitter.EmitRowStats(ApiMd.Assemblies, AppDb.ApiTargets().Table<CliRowStats>());

        [CmdOp("ecma/emit/blobs")]
        void EmitBlobs()
            => CliEmitter.EmitBlobs(Dst);

        [CmdOp("ecma/emit/msil")]
        void EmitMsil()
            => Cli.EmitIl(Dst);

        [CmdOp("ecma/emit/ildat")]
        void EmitIlDat()
            => CliEmitter.EmitIlDat(Dst);

        [CmdOp("ecma/emit/fields")]
        void EmitFields()
            => CliEmitter.EmitFieldMetadata(Dst);

        [CmdOp("ecma/emit/literals")]
        void EmitLiterals()
            => CliEmitter.EmitLiterals(Dst);

        [CmdOp("ecma/emit/headers")]
        void EmitHeaders()
            => CliEmitter.EmitSectionHeaders(Dst);

        static FilePath EcmaArchive(FilePath src)
            => AppDb.Archive("ecma").Path(src.FileName.WithExtension(FS.ext($"{src.Hash}.txt")));

        void EmitMetadumps(ItemList<uint,FilePath> src)        
        {
            iter(src, file => {
                if(file.Value.IsNot(FS.ext("resources.dll")))
                {
                    CliEmitter.EmitMetadump(file.Value, EcmaArchive(file.Value));
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
                {
                    EmitMetadumps(ListArchives.load(src, parse, Emitter));
                }
                else
                {
                    CliEmitter.EmitMetadump(src, EcmaArchive(src));
                }
            }
        }

        [CmdOp("api/emit/corelib")]
        void EmitCorLib()
        {
            var src = Clr.corlib();
            var reader = CliReader.create(src);
            var blobs = reader.ReadBlobs();
            for(var i=0; i<blobs.Length; i++)
            {
                ref readonly var blob = ref skip(blobs,i);
                Write(string.Format("{0,-8} | {1,-8} | {2,-8}", blob.Seq, blob.Offset, blob.DataSize));
            }
        }
    }
}