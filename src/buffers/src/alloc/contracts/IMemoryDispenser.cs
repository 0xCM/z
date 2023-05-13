//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IMemoryDispenser : IAllocDispenser
    {
        MemorySeg Memory(ByteSize size);
    }
}