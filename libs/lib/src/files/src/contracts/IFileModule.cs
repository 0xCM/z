//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IFileModule : IFile
    {
        FileModuleKind ModuleKind {get;}

    }

    [Free]
    public interface IFileModule<T> : IFileModule, IFile<FS.FilePath>
        where T : struct, IFileModule<T>
    {
        FS.FilePath Path {get;}

        FS.FilePath ILocatable<FS.FilePath>.Location
            => Path;
    }
}