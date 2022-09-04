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

        FilePath ExtractPath(_ApiHostUri host, FileKind kind)
            => Extracts().Path(ApiFiles.file(host, kind));

        Files HexExtracts()
            => Extracts().Files(FileKind.HexDat);

        Files HexExtracts(PartId part)
            => HexExtracts().Where(path => path.FileName.StartsWith($"{part.PartName().Format()}."));

        Files AsmExtracts()
            => Extracts().Files(FileKind.Asm);

        Files AsmExtracts(PartId part)
            => AsmExtracts().Where(path => path.FileName.StartsWith($"{part.PartName().Format()}."));

        Files MsilExtracts()
            => Extracts().Files(FileKind.Il);

        Files MsilExtracts(PartId part)
            => MsilExtracts().Where(path => path.FileName.StartsWith($"{part.PartName().Format()}."));

        IApiPackArchive Archive()
            => ApiPackArchive.create(Root);

        FilePath HexExtractPath(PartId src)
            => ExtractPath(src, FileKind.HexDat);

        FilePath CsvExtractPath(PartId part)
            => ExtractPath(part, FileKind.Csv);

        FilePath AsmExtractPath(PartId part)
            => ExtractPath(part, FileKind.Asm);

        FilePath MsilPath(_ApiHostUri host)
            => Extracts().Path(ApiFiles.hostfile(host,FileKind.Il.Ext()));

        FilePath HexExtractPath(_ApiHostUri src)
            => ExtractPath(src, FileKind.HexDat);

        FilePath CsvExtractPath(_ApiHostUri src)
            => ExtractPath(src, FileKind.Csv);

        FilePath AsmExtractPath(_ApiHostUri src)
            => ExtractPath(src, FileKind.Asm);

        FileName RegionFile()
            => FS.file("memory.regions", FileKind.Csv);

        FileName RegionHashFile()
            => FS.file("memory.regions.hash", FileKind.Csv);

        FileName PartitionFile()
            => FS.file("process.partitions", FileKind.Csv);

        FileName PartitionHashFile()
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

        FileName DumpFile(Process process)
            => FS.file(ProcDumpName.create(process,Timestamp).Format(false), FileKind.Dmp);

        FilePath DumpPath(Process process)
            => Context().Path(DumpFile(process)).CreateParentIfMissing();
    }
}