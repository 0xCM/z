//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IKindedArchive<K> : IFileArchive
        where K : IFileKind<K>, new()
    {
        Deferred<FileUri> Files(K kind);
    }
}