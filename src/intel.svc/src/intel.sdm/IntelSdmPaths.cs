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
        public IDbArchive Sources()
            => AppDb.DbIn("intel");

        public IDbArchive Targets()
            => AppDb.DbOut("asm.db.check");

        public FilePath SourceTable<T>()
            where T : struct
                => Sources().Table<T>();

        public IDbArchive Sources(string scope)
            => Sources().Sources(scope);

        public FilePath TargetTable<T>()
            where T : struct
                => Targets().Table<T>();

        public IDbArchive Logs()
            => AppDb.Logs("intel.sdm");

        public FilePath SigFixupConfig()
            => AppDb.Env().Path("asm.sigs.fixups", FileKind.Map);

        public FilePath SigNormalConfig()
            => AppDb.Env().Path("asm.sigs.normalize", FileKind.Map);

        public FilePath OcFixupConfig()
            => AppDb.Env().Path("asm.opcodes.fixups", FileKind.Map);

        public FilePath SplitConfig()
            => AppDb.Env().Path(FS.file("sdm.splits", FS.Csv));

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