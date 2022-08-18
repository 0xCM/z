//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        [Op]
        public static FS.FilePath PartPath(this IPart part)
            => FS.path(part.Owner.Location);

        [Op]
        public static FS.FolderPath Clear(this FS.FolderPath src, bool recurse = false)
        {
            FS.clear(src, recurse);
            return src;
        }

        [Op]
        public static List<FS.FilePath> Clear(this FS.FolderPath src, List<FS.FilePath> dst, bool recurse = false)
            => FS.clear(src, dst, recurse);

        public static FS.FilePath CopyTo(this FS.FilePath src, FS.FilePath dst, bool overwrite = true)
        {
            var result = FS.FilePath.Empty;
            if(src.Exists)
            {
                File.Copy(src.Name, dst.CreateParentIfMissing().Name, overwrite);
                result = dst;
            }
            return result;
        }

        [Op]
        public static FS.FilePath CopyTo(this FS.FilePath src, FS.FolderPath dst, bool overwrite = true)
        {
            if(src.Exists)
            {
                dst.Create();
                var path = dst + src.FileName;
                File.Copy(src.Name, path.Name, overwrite);
                return path;
            }
            else
                return FS.FilePath.Empty;
        }

        [Op]
        public static FS.Files Clear(this FS.Files src)
            => FS.clear(src);

    }
}