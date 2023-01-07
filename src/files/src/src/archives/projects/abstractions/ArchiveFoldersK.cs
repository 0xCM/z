//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class ArchiveFolders<K> : ArchiveIndex<K,FolderPath>
        where K : IDataType<K>, new() 
    {
        
    }

}