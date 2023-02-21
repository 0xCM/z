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
        IDbArchive SdmDb()
            => AppSettings.SdmDb();
        
        public IDbArchive Sources()
            => SdmDb().Scoped("sources");

        public IDbArchive Targets()
            => SdmDb().Scoped("targets");

        public IDbArchive Settings()
            => SdmDb().Scoped("settings");

        public IDbArchive Logs()
            => SdmDb().Scoped("logs");

        public IDbArchive Sources(string scope)
            => Sources().Sources(scope);

        public FilePath TargetTable<T>()
            where T : struct
                => Targets().Table<T>();

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
            => Targets().Path(FS.file(string.Format("intel-sdm-vol{0}-{1}", vol, "lined"), FS.Txt));

        public FilePath TocImportDoc()
            => Targets().Path(FS.file("sdm.toc", FS.Txt));

        public FilePath ProcessLog(string name)
            => Logs().Path(name,FileKind.Log);

        public ReadOnlySeq<FilePath> TocPaths()
            => Targets().Files().Where(f => IsTocPart(f)).Array().Sort();

        public FilePath TocDst()
            => Targets().Table<TocEntry>(sdm);

        public FilePath FormDetailDst()
            => Targets().Table<SdmFormDetail>(sdm);

        public FilePath CharMapDst()
            => Targets().Path(FS.file("sdm.charmap", FS.Config));

        public FilePath UnmappedCharLog()
            => Logs().Path("sdm.unmapped", FileKind.Log);

        public FilePath SdmSrcPath()
            => Sources().Path(FS.file("intel-sdm", FS.Txt));

        public IDbArchive CsvSources()
            => Sources().Sources("sdm.instructions");

        public FilePath TokensDst(string sort)
            => Targets().Path(sort,FileKind.Csv);

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