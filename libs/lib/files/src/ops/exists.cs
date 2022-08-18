//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct FS
    {
        [MethodImpl(Inline), Op]
        public static bool exists(FolderPath src)
            => Directory.Exists(src.Name);

        [MethodImpl(Inline), Op]
        public static bool exists(FilePath src)
            => File.Exists(src.Name);
    }
}