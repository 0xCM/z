//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FS
    {
        public static FileKind kind(FileExt src)
            => FileTypes.kind(src);

        public static FileKind kind(FilePath src)
            => FileTypes.kind(src);
    }
}