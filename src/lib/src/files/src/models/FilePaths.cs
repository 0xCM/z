//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class FilePaths : Seq<FilePaths,FilePath>
    {
        public FilePaths()
        {

        }

        public FilePaths(params FilePath[] src)
            : base(src)
        {

        }

        [MethodImpl(Inline)]
        public static implicit operator FilePaths(FilePath[] src)
            => new FilePaths(src);

        [MethodImpl(Inline)]
        public static implicit operator FilePaths(Files src)
            => new FilePaths(src.Data);
    }
}