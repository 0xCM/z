//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        [Op]
        public static FilePath PartPath(this IPart part)
            => FS.path(part.Owner.Location);

        [Op]
        public static FolderPath Clear(this FolderPath src, bool recurse = false)
        {
            FS.clear(src, recurse);
            return src;
        }

        [Op]
        public static List<FilePath> Clear(this FolderPath src, List<FilePath> dst, bool recurse = false)
            => FS.clear(src, dst, recurse);

        public static FilePath CopyTo(this FilePath src, FilePath dst, bool overwrite = true)
        {
            var result = FilePath.Empty;
            if(src.Exists)
            {
                File.Copy(src.Name, dst.CreateParentIfMissing().Name, overwrite);
                result = dst;
            }
            return result;
        }

        [Op]
        public static FilePath CopyTo(this FilePath src, FolderPath dst, bool overwrite = true)
        {
            if(src.Exists)
            {
                dst.Create();
                var path = dst + src.FileName;
                File.Copy(src.Name, path.Name, overwrite);
                return path;
            }
            else
                return FilePath.Empty;
        }

        [Op]
        public static FS.Files Clear(this FS.Files src)
            => FS.clear(src);

    }
}