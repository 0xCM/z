//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class FolderPaths : Seq<FolderPaths,FolderPath>
    {
        public FolderPaths()
        {

        }

        [MethodImpl(Inline)]
        public FolderPaths(FolderPath[] src)
            : base(src)
        {

        }

        public override string Format()
            => FS.format(this);

        [MethodImpl(Inline)]
        public static implicit operator FolderPaths(FolderPath[] src)
            => new FolderPaths(src);

        [MethodImpl(Inline)]
        public static implicit operator FolderPath[](FolderPaths src)
            => src.Storage;
    }
}