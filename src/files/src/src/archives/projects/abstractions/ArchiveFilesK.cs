//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class ArchiveFiles<K> : ArchiveIndex<K,FileUri>
        where K : IDataType<K>, new() 
    {

    }

}