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
        public static Outcome symlink(FS.FolderPath src, FS.FolderPath dst, bool deleteExising = false)
        {
            try
            {
                if(deleteExising)
                    src.Delete();

                var outcome = Kernel32.CreateSymLink(src.Name, dst.Name, SymLinkKind.Directory);
                if(outcome)
                    return true;
                else
                    return (false, DirectoryLinkCreationFailed.Format(src, dst, EmptyString));
            }
            catch(Exception e)
            {
                return (false, DirectoryLinkCreationFailed.Format(src, dst, e.ToString()));
            }
        }

        [Op]
        public static Outcome<Arrow<FS.FilePath>> symlink(FS.FilePath link, FS.FilePath dst, bool deleteExising = false)
        {
            try
            {
                if(deleteExising)
                    link.Delete();

                link.FolderPath.Create();

                var outcome = Kernel32.CreateSymLink(link.Name, dst.Name, SymLinkKind.File);
                if(outcome)
                    return (true,(link,dst));
                else
                    return (false, FileLinkCreationFailed.Format(link, dst, EmptyString));

            }
            catch(Exception e)
            {
                return (false, FileLinkCreationFailed.Format(link, dst, e.ToString()));
            }
        }

        static MsgPattern<FS.FileUri, FS.FileUri, string> FileLinkCreationFailed => "Failed to create link {0} -> {1}:{2}";

        static MsgPattern<FS.FolderPath, FS.FolderPath, string> DirectoryLinkCreationFailed => "Failed to create link {0} -> {1}:{2}";
    }
}