//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IFileRef : IFile<FS.FilePath>
    {
        FileKind Kind {get;}

        FS.FilePath Path {get;}

        FS.FilePath ILocatable<FS.FilePath>.Location
            => Path;
    }
}