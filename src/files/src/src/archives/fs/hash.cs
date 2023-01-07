//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Security.Cryptography;

    partial struct FS
    {
        [Op]
        public static HashedFile hash(FilePath src)
            => new (src, new FileHash(src.Hash, sys.@as<Hash128>(sys.span(MD5.HashData(src.ReadBytes())))));
     
        [MethodImpl(Inline), Op]
        public static bool has(FilePath src, FileExt ext)
            => src.Ext == ext;
    }
}