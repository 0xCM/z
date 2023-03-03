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
            => new (src, new FileHash(sys.@as<Hash128>(sys.span(MD5.HashData(src.ReadBytes()))), src.Hash));
     
        public static HashedFile hash(MemoryFile src)
        {
            var md5 = sys.@as<Hash128>(MD5.HashData(src.Bytes));
            return new HashedFile(src.Path, new FileHash(md5, src.Path.Hash));
        }

        [MethodImpl(Inline), Op]
        public static bool has(FilePath src, FileExt ext)
            => src.Ext == ext;
    }
}