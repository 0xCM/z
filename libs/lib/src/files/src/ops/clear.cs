//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    using static sys;

    partial struct FS
    {
        public static void clear(FolderPath src, bool recurse = false)
        {
            if(Directory.Exists(src.Name))
            {
                foreach(var f in src.Files(recurse))
                    f.Delete();
            }
        }

        public static List<FilePath> clear(FolderPath src, List<FilePath> dst, bool recurse = false)
        {
            if(Directory.Exists(src.Name))
            {
                foreach(var f in src.Files(recurse))
                    dst.Add(f.Delete());
            }
            return dst;
        }

        public static FS.Files clear(FS.Files src)
        {
            var dst = list<FilePath>();
            foreach(var file in src)
            {
                if(file.Exists)
                    dst.Add(file.Delete());
            }
            return dst.ToArray();
        }
    }
}