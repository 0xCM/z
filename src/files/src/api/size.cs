//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    partial struct FS
    {
        [MethodImpl(Inline), Op]
        public static ByteSize size(FilePath src)
            => new FileInfo(src.Name).Length;
    }
}