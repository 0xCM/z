//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IApiPack : IRootedArchive, IExpr
    {
        Timestamp Timestamp {get;}

        bool INullity.IsEmpty
            => Timestamp == 0;

        string IExpr.Format()
            => string.Format("{0}: {1}", Timestamp, Root);

        IImmArchive ImmArchive()
            => new ImmArchive(Root + FS.folder("imm"));

        IDbTargets Context()
            => Targets("context");

        IDbTargets Analysis()
            => Targets("analysis");

        IDbTargets Docs()
            => Targets("docs");

        IDbTargets Docs(string scope)
            => Docs().Targets(scope);

        IDbTargets Tokens()
            => Metadata().Targets("tokens");

        IDbTargets Extracts()
            => Targets("extracts");

        IDbTargets Metadata()
            => Targets("metadata");

        IDbTargets Runtime()
            => Targets("runtime");

        IDbTargets Metadata(string scope)
            => Metadata().Targets(scope);

        FilePath ExtractPath(PartId part, FileKind kind)
            => Extracts().Path(FS.file(part.Format(), kind));

        FilePath ExtractPath(ApiHostUri host, FileKind kind)
            => Extracts().Path(FS.file(host, kind));

        FS.Files HexExtracts()
            => Extracts().Files(FileKind.HexDat);

        FS.Files HexExtracts(PartId part)
            => HexExtracts().Where(path => path.FileName.StartsWith($"{part.PartName().Format()}."));

        FS.Files AsmExtracts()
            => Extracts().Files(FileKind.Asm);

        FS.Files AsmExtracts(PartId part)
            => AsmExtracts().Where(path => path.FileName.StartsWith($"{part.PartName().Format()}."));

        FS.Files MsilExtracts()
            => Extracts().Files(FileKind.Il);

        FS.Files MsilExtracts(PartId part)
            => MsilExtracts().Where(path => path.FileName.StartsWith($"{part.PartName().Format()}."));

        IApiPackArchive Archive()
            => ApiPackArchive.create(Root);

        FilePath HexExtractPath(PartId src)
            => ExtractPath(src, FileKind.HexDat);

        FilePath CsvExtractPath(PartId part)
            => ExtractPath(part, FileKind.Csv);

        FilePath AsmExtractPath(PartId part)
            => ExtractPath(part, FileKind.Asm);

        FilePath MsilPath(ApiHostUri host)
            => Extracts().Path(FS.hostfile(host,FileKind.Il.Ext()));

        FilePath HexExtractPath(ApiHostUri src)
            => ExtractPath(src, FileKind.HexDat);

        FilePath CsvExtractPath(ApiHostUri src)
            => ExtractPath(src, FileKind.Csv);

        FilePath AsmExtractPath(ApiHostUri src)
            => ExtractPath(src, FileKind.Asm);

        FS.FileName RegionFile()
            => FS.file("memory.regions", FileKind.Csv);

        FS.FileName RegionHashFile()
            => FS.file("memory.regions.hash", FileKind.Csv);

        FS.FileName PartitionFile()
            => FS.file("process.partitions", FileKind.Csv);

        FS.FileName PartitionHashFile()
            => FS.file("process.partitions.hash", FileKind.Csv);

        FilePath PartitionPath()
            => Context().Path(PartitionFile());

        FilePath RegionPath()
            => Context().Path(RegionFile());

        FilePath RegionHashPath()
            => Context().Path(RegionHashFile());

        FilePath PartitionHashPath()
            => Context().Path(PartitionHashFile());

        FilePath ProcessModules()
            => Context().Path("process.modules", FileKind.Csv);

        FS.FileName DumpFile(Process process)
            => FS.file(ProcDumpName.create(process,Timestamp).Format(false), FileKind.Dmp);

        FilePath DumpPath(Process process)
            => Context().Path(DumpFile(process)).CreateParentIfMissing();
    }
}