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
    public interface IBinaryModule<T> : IBinaryModule, IFile<FileUri>
        where T : struct, IBinaryModule<T>
    {
        FileUri Path {get;}

        FileUri ILocatable<FileUri>.Location
            => Path;
    }
}