//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Binary
{
    public interface IStreamLocator<T>
        where T : unmanaged
    {
        MemoryAddress Locate(IBinaryRule rule, IBinaryStream<T> src);
    }
}