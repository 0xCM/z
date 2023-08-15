//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    partial struct FS
    {
        [Op]
        public static Outcome<Symlink> symlink(FolderPath src, FolderPath dst, bool deleteExising = false)
        {
            try
            {
                if(deleteExising)
                    src.Delete();

                var outcome = Kernel32.CreateSymLink(src.Absolute().Format(), dst.Absolute().Format(), SymLinkKind.Directory);
                if(outcome)
                    return new Symlink(SymLinkKind.Directory, src, dst);
                else
                    return (false, DirectoryLinkCreationFailed.Format(src, dst, EmptyString));
            }
            catch(Exception e)
            {
                return (false, DirectoryLinkCreationFailed.Format(src, dst, e.ToString()));
            }
        }

        [Op]
        public static Outcome<Symlink> symlink(FilePath src, FilePath dst, bool deleteExising = false)
        {
            try
            {
                if(deleteExising)
                    src.Delete();

                src.FolderPath.Create();

                var outcome = Kernel32.CreateSymLink(src.Absolute().Format(), dst.Absolute().Format(), SymLinkKind.File);
                if(outcome)
                    return new Symlink(SymLinkKind.File, src, dst);
                else
                    return (false, FileLinkCreationFailed.Format(src, dst, EmptyString));

            }
            catch(Exception e)
            {
                return (false, FileLinkCreationFailed.Format(src, dst, e.ToString()));
            }
        }

        static MsgPattern<FileUri, FileUri, string> FileLinkCreationFailed => "Failed to create link {0} -> {1}:{2}";

        static MsgPattern<FolderPath, FolderPath, string> DirectoryLinkCreationFailed => "Failed to create link {0} -> {1}:{2}";
    }
}