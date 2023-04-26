//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    partial struct FS
    { 
        [Op]
        public static FileInfo info(FilePath src)
            => new FileInfo(src.Name);

        public static IEnumerable<FileInfo> info(IEnumerable<FilePath> src)
            => from path in src select info(path);
    }
}