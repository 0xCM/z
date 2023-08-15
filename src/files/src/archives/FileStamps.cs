//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class FileStamps
    {
        public static IDbArchive archive(Timestamp ts, IDbArchive dst)
            => dst.Scoped(ts.Format());

        public static FileName timestamped(string name, FileExt ext)
            => FS.file(string.Format("{0}.{1}", name, (sys.timestamp()).Format()),ext);

        [Op]
        public static FilePath timestamped(FilePath src)
        {
            var name = src.FileName.WithoutExtension;
            var ext = src.Ext;
            var stamped = FS.file(string.Format("{0}.{1}.{2}", name, sys.timestamp(), ext));
            return src.FolderPath + stamped;
        }

        public static Outcome timestamp(FolderPath src, out Timestamp dst)
        {
            dst = Timestamp.Zero;
            if(src.IsEmpty)
                return false;

            var fmt = src.Format(PathSeparator.FS);
            var idx = fmt.LastIndexOf(Chars.FSlash);
            if(idx == NotFound)
                return false;

            var outcome = Timing.parse(fmt.RightOfIndex(idx), out dst);
            if(outcome)
            {
                return true;
            }
            else
                return(false, outcome.Message);
        }        
    }
}