//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IFileKind<K>
        where K : new()
    {
        K Descriptor {get;}
    }

    public interface IFileKind : IFileKind<FileKind>
    {

    }
}