//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Z0.Parts.IntelIntrinsics;
    using static IntrinsicsDoc;
    using static sys;

    public partial class IntelInx : WfSvc<IntelInx>
    {
        static internal ref readonly PartAssets Assets => ref AssetData;

        IDbSources Sources()
            => AppDb.DbIn("intel");

        IDbTargets Targets()
            => AppDb.AsmDb("intrinsics");

        FilePath XmlSource()
            => Sources().Path(XmlFile);

        FilePath DeclPath()
            => Targets().Path(DeclFile);

        FilePath AlgPath()
            => Targets().Path(AlgFile);

        XmlDoc LoadDocXml()
            => XmlSource().ReadUtf8();

        Index<IntrinsicDef> ParseDoc()
            => read(LoadDocXml());

        public void EmitAlgorithms(ReadOnlySpan<IntrinsicDef> src)
        {
            var dst = text.emitter();
            AlgRender.render(src,dst);
            FileEmit(dst.Emit(), AlgPath(), TextEncodingKind.Utf8);
        }

        public void EmitDeclarations(ReadOnlySpan<IntrinsicDef> src)
        {
            var dst = DeclPath();
            var flow = EmittingFile(dst);
            var count = src.Length;
            using var writer = dst.Writer();
            for(var i=0; i<count; i++)
                writer.WriteLine(string.Format("{0};", skip(src,i).Sig()));
            EmittedFile(flow, count);
        }

        public Index<IntelIntrinsicRecord> EmitRecords(Index<IntrinsicDef> src)
        {
            var dst = alloc<IntelIntrinsicRecord>(src.Count);
            records(src,dst);
            TableEmit(dst.Sort().Resequence(), Targets().Table<IntelIntrinsicRecord>());
            return dst;
        }

        public Index<IntrinsicDef> RunEtl()
        {
            Targets().Clear();
            var parsed = ParseDoc();
            EmitAlgorithms(parsed);
            var records = EmitRecords(parsed);
            EmitDeclarations(parsed);
            return parsed;
        }

        const string intrinsics = "intel.intrinsics";

        const string sep = ".";

        const string refs = intrinsics + sep + nameof(refs);

        const string checks = intrinsics + sep + nameof(checks);

        const string specs = intrinsics + sep + nameof(specs);

        const string algs = intrinsics + sep + nameof(algs);

        const string sigs = intrinsics + sep + nameof(sigs);

        public static FileName AlgFile => FS.file(algs, FS.Txt);

        public static FileName DataFile => FS.file(intrinsics, FS.Csv);

        public static FileName XmlFile => FS.file(intrinsics, FS.Xml);

        public static FileName DeclFile = FS.file(intrinsics, FS.H);
    }
}