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

        FS.FilePath ExtractPath(PartId part, FileKind kind)
            => Extracts().Path(FS.file(part.Format(), kind));

        FS.FilePath ExtractPath(ApiHostUri host, FileKind kind)
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

        FS.FilePath HexExtractPath(PartId src)
            => ExtractPath(src, FileKind.HexDat);

        FS.FilePath CsvExtractPath(PartId part)
            => ExtractPath(part, FileKind.Csv);

        FS.FilePath AsmExtractPath(PartId part)
            => ExtractPath(part, FileKind.Asm);

        FS.FilePath MsilPath(ApiHostUri host)
            => Extracts().Path(FS.hostfile(host,FileKind.Il.Ext()));

        FS.FilePath HexExtractPath(ApiHostUri src)
            => ExtractPath(src, FileKind.HexDat);

        FS.FilePath CsvExtractPath(ApiHostUri src)
            => ExtractPath(src, FileKind.Csv);

        FS.FilePath AsmExtractPath(ApiHostUri src)
            => ExtractPath(src, FileKind.Asm);

        FS.FileName RegionFile()
            => FS.file("memory.regions", FileKind.Csv);

        FS.FileName RegionHashFile()
            => FS.file("memory.regions.hash", FileKind.Csv);

        FS.FileName PartitionFile()
            => FS.file("process.partitions", FileKind.Csv);

        FS.FileName PartitionHashFile()
            => FS.file("process.partitions.hash", FileKind.Csv);

        FS.FilePath PartitionPath()
            => Context().Path(PartitionFile());

        FS.FilePath RegionPath()
            => Context().Path(RegionFile());

        FS.FilePath RegionHashPath()
            => Context().Path(RegionHashFile());

        FS.FilePath PartitionHashPath()
            => Context().Path(PartitionHashFile());

        FS.FilePath ProcessModules()
            => Context().Path("process.modules", FileKind.Csv);

        FS.FileName DumpFile(Process process)
            => FS.file(ProcDumpName.create(process,Timestamp).Format(false), FileKind.Dmp);

        FS.FilePath DumpPath(Process process)
            => Context().Path(DumpFile(process)).CreateParentIfMissing();
    }
}