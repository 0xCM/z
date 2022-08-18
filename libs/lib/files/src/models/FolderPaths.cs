//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class FolderPaths : Seq<FolderPaths,FS.FolderPath>
    {
        public FolderPaths()
        {

        }

        [MethodImpl(Inline)]
        public FolderPaths(FS.FolderPath[] src)
            : base(src)
        {

        }

        public override string Format()
            => FS.format(this);

        [MethodImpl(Inline)]
        public static implicit operator FolderPaths(FS.FolderPath[] src)
            => new FolderPaths(src);

        [MethodImpl(Inline)]
        public static implicit operator FS.FolderPath[](FolderPaths src)
            => src.Storage;
    }
}