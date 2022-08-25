//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IFileRef : IFile<FilePath>
    {
        FileKind Kind {get;}

        FilePath Path {get;}

        FilePath ILocatable<FilePath>.Location
            => Path;
    }
}