//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IPageAllocator : IBufferAllocator
    {
        uint PageCount {get;}

        MemoryAddress Alloc();
    }
}