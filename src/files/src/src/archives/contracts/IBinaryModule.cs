//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IBinaryModule : IFile
    {
        FileModuleKind ModuleKind {get;}
    }

    [Free]
    public interface IBinaryModule<T> : IBinaryModule, IFile<FilePath>
        where T : struct, IBinaryModule<T>
    {
        FilePath Path {get;}

        FilePath ILocatable<FilePath>.Location
            => Path;
    }
}