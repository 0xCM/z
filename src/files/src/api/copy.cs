//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FS
    {
        public static FilePath copy(FilePath src, FilePath dst, bool overwrite = true)
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
        public static FilePath copy(FilePath src, FolderPath dst, bool overwrite = true)
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
    }
}