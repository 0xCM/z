//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public unsafe interface IPtr
    {
        void* Target {get;}

        MemoryAddress Address
            => Target;
    }

    [Free]
    public unsafe interface IPtr<T> : IPtr
        where T : unmanaged
    {
        new T* Target {get;}

        ref T this[long index]{get;}

        ref T this[ulong index]{get;}

        void* IPtr.Target
            => Target;
    }
}