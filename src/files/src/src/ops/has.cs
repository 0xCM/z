//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Security.Cryptography;


    partial struct FS
    {
        public static Hash128 hash(FilePath src)
        {
            using var hasher = MD5.Create();
            return sys.@as<Hash128>(sys.span(hasher.ComputeHash(src.ReadBytes())));
        }
     
        [MethodImpl(Inline), Op]
        public static bool has(FilePath src, FileExt ext)
            => src.Ext == ext;
    }
}