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
    public interface IBinaryModule<T> : IBinaryModule
        where T : IBinaryModule<T>, new()
    {

    }
}