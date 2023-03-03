//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FS
    { 
        public static FileIndex index(params FilePath[] src)
        {
            var dst = new FileIndex();
            dst.Include(src);
            return dst;
        }
    }
}