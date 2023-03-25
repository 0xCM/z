//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    public interface IApiPack : IDbArchive, IExpr
    {
        Timestamp Timestamp {get;}

        bool INullity.IsEmpty
            => Timestamp == 0;

        string IExpr.Format()
            => string.Format("{0}: {1}", Timestamp, Root);

        IImmArchive ImmArchive()
            => new ImmArchive(Root + FS.folder("imm"));

        DbArchive Context()
            => Targets("context");

        DbArchive Analysis()
            => Targets("analysis");

        DbArchive Extracts()
            => Targets("extracts");

        FilePath ExtractPath(PartName part, FileKind kind)
            => Extracts().Path(FS.file(part.Format(), kind));

        FilePath ExtractPath(ApiHostUri host, FileKind kind)
            => Extracts().Path(ApiFiles.file(host, kind));

        IEnumerable<FilePath> HexExtracts()
            => Extracts().Files(FileKind.HexDat);

        IEnumerable<FilePath> HexExtracts(PartName part)
            => HexExtracts().Where(path => path.FileName.StartsWith($"{part.Format()}."));

        IEnumerable<FilePath> AsmExtracts()
            => Extracts().Files(FileKind.Asm);

        IEnumerable<FilePath> AsmExtracts(PartName part)
            => AsmExtracts().Where(path => path.FileName.StartsWith($"{part.Format()}."));

        IEnumerable<FilePath> MsilExtracts()
            => Extracts().Files(FileKind.Il);

        IEnumerable<FilePath> MsilExtracts(PartName part)
            => MsilExtracts().Where(path => path.FileName.StartsWith($"{part.Format()}."));

        IApiPackArchive Archive()
            => ApiPackArchive.create(Root);

        FilePath HexExtractPath(PartName src)
            => ExtractPath(src, FileKind.HexDat);

        FilePath CsvExtractPath(PartName part)
            => ExtractPath(part, FileKind.Csv);

        FilePath AsmExtractPath(PartName part)
            => ExtractPath(part, FileKind.Asm);

        FilePath HexExtractPath(ApiHostUri src)
            => ExtractPath(src, FileKind.HexDat);

        FilePath CsvExtractPath(ApiHostUri src)
            => ExtractPath(src, FileKind.Csv);

        FilePath AsmExtractPath(ApiHostUri src)
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
    }
}