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
        public IDbTargets Output()
            => AppDb.AsmDb("sdm");

        public FS.FilePath SdmTable<T>()
            where T : struct
                => Output().Table<T>();

        public IDbSources Sources()
            => AppDb.DbIn(intel);

        public IDbSources Sources(string scope)
            => Sources().Sources(scope);

        public IDbSources Settings()
            => AppDb.EnvConfig();

        public IDbTargets Logs()
            => AppDb.Logs("intel.sdm");

        public FS.FilePath SigFixupConfig()
            => Settings().Path("asm.sigs.fixups", FileKind.Map);

        public FS.FilePath SigNormalConfig()
            => Settings().Path("asm.sigs.normalize", FileKind.Map);

        public FS.FilePath OcFixupConfig()
            => Settings().Path("asm.opcodes.fixups", FileKind.Map);

        public FS.FilePath SplitConfig()
            => Settings().Path(FS.file("sdm.splits", FS.Csv));

        public FS.FilePath SdmSrcVol(byte vol)
            => Sources().Path(FS.file(string.Format("intel-sdm-vol{0}", vol), FS.Txt));

        public FS.FilePath SdmDstVol(byte vol)
            => Output().Path(FS.file(string.Format("intel-sdm-vol{0}-{1}", vol, "lined"), FS.Txt));

        public FS.FilePath TocImportDoc()
            => Output().Path(FS.file("sdm.toc", FS.Txt));

        public FS.FilePath ProcessLog(string name)
            => Logs().Path(name,FileKind.Log);

        public ReadOnlySeq<FS.FilePath> TocPaths()
            => Output().Files().Where(f => IsTocPart(f)).Array().Sort();

        public FS.FilePath TocDst()
            => Output().Table<TocEntry>(sdm);

        public FS.FilePath FormDetailDst()
            => Output().Table<SdmFormDetail>(sdm);

        public FS.FilePath CharMapDst()
            => Output().Path(FS.file("sdm.charmap", FS.Config));

        public FS.FilePath UnmappedCharLog()
            => Logs().Path("sdm.unmapped", FileKind.Log);

        public FS.FilePath SdmSrcPath()
            => Sources().Path(FS.file("intel-sdm", FS.Txt));

        public IDbSources CsvSources()
            => Sources().Sources("sdm.instructions");

        public FS.FilePath TokensDst(string sort)
            => Output().Path(sort,FileKind.Csv);

        static bool IsTocPart(FS.FilePath src)
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