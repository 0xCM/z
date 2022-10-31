//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static SdmModels;
    using static ApiAtomic;

    public class IntelSdmPaths : WfSvc<IntelSdmPaths>
    {
        public IDbArchive Output()
            => AppDb.AsmDb("sdm");

        public FilePath SdmTable<T>()
            where T : struct
                => Output().Table<T>();

        public IDbArchive Sources()
            => AppDb.DbIn(intel);

        public IDbArchive Sources(string scope)
            => Sources().Sources(scope);

        public IDbArchive Settings()
            => AppDb.Env();

        public IDbArchive Logs()
            => AppDb.Logs("intel.sdm");

        public FilePath SigFixupConfig()
            => Settings().Path("asm.sigs.fixups", FileKind.Map);

        public FilePath SigNormalConfig()
            => Settings().Path("asm.sigs.normalize", FileKind.Map);

        public FilePath OcFixupConfig()
            => Settings().Path("asm.opcodes.fixups", FileKind.Map);

        public FilePath SplitConfig()
            => Settings().Path(FS.file("sdm.splits", FS.Csv));

        public FilePath SdmSrcVol(byte vol)
            => Sources().Path(FS.file(string.Format("intel-sdm-vol{0}", vol), FS.Txt));

        public FilePath SdmDstVol(byte vol)
            => Output().Path(FS.file(string.Format("intel-sdm-vol{0}-{1}", vol, "lined"), FS.Txt));

        public FilePath TocImportDoc()
            => Output().Path(FS.file("sdm.toc", FS.Txt));

        public FilePath ProcessLog(string name)
            => Logs().Path(name,FileKind.Log);

        public ReadOnlySeq<FilePath> TocPaths()
            => Output().Files().Where(f => IsTocPart(f)).Array().Sort();

        public FilePath TocDst()
            => Output().Table<TocEntry>(sdm);

        public FilePath FormDetailDst()
            => Output().Table<SdmFormDetail>(sdm);

        public FilePath CharMapDst()
            => Output().Path(FS.file("sdm.charmap", FS.Config));

        public FilePath UnmappedCharLog()
            => Logs().Path("sdm.unmapped", FileKind.Log);

        public FilePath SdmSrcPath()
            => Sources().Path(FS.file("intel-sdm", FS.Txt));

        public IDbArchive CsvSources()
            => Sources().Sources("sdm.instructions");

        public FilePath TokensDst(string sort)
            => Output().Path(sort,FileKind.Csv);

        static bool IsTocPart(FilePath src)
        {
            var f = src.FileName.Format();
            if(src.Ext == FS.Txt)
            {
                var name = src.WithoutExtension.Format();
                if(name.Contains("toc") && name.EndsWithDigit())
                    return true;
            }
            return false;
        }
    }
}