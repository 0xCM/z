//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IImageDirectory
    {
        PeDirectoryKind DirectoryKind {get;}

        string Format();
    }

    public interface IImageDirectory<T> : IImageDirectory
        where T : unmanaged
    {

    }
}