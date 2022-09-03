
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IBufferAllocator : IDisposable
    {
        MemoryAddress BaseAddress {get;}

        ByteSize Size {get;}
    }

    [Free]
    public interface IBufferAllocator<T> : IBufferAllocator
    {
        bool Alloc(out T dst);
    }

    [Free]
    public interface IBufferAllocator<S,T> : IBufferAllocator
    {
        bool Alloc(S src, out T dst);
    }
}