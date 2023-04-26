//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Roslyn.Utilities;

    partial struct FS
    {
        // public static FileKind kind(FileExt src)
        //     => FileKinds.kind(src);

        // public static FileKind kind(FilePath src)
        //     => FileKinds.kind(src);

        public static FileKind FileKind(FileExt src)
            => FileKinds.kind(src);

        public static FileKind FileKind(FilePath src)
            => FileKinds.kind(src);

        public static PathKind PathKind(IFsEntry src)
            => PathUtilities.GetPathKind(src.Name);
    }
}