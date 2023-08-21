
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;


[Free]
public interface IStringAllocator<T> : IAllocation
    where T : IMemoryString
{
    bool Alloc(ReadOnlySpan<char> src, out T dst);
}

[Free]
public interface IPageAllocator : IAllocation
{
    uint PageCount {get;}

    MemoryAddress Alloc();
}