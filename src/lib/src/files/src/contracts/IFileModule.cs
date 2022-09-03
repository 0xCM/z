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
    public interface IFileModule<T> : IFileModule, IFile<FilePath>
        where T : struct, IFileModule<T>
    {
        FilePath Path {get;}

        FilePath ILocatable<FilePath>.Location
            => Path;
    }
}