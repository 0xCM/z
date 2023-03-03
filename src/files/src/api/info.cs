//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FS
    { 
        [Op]
        public static FileInfo info(FilePath src)
            => new FileInfo(src.Name);
    }
}