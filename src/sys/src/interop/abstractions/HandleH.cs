//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    [Free]
    public abstract class Handle<H> : IHandle<H>
        where H : Handle<H>, new()
    {
        public readonly MemoryAddress Address;

        protected Handle(MemoryAddress src)
        {
            Address = src;
        }        

        MemoryAddress IHandle.Address
            => Address;

        void IDisposable.Dispose()
        {
            if(Address.IsNonZero)
                Kernel32.CloseHandle(Address);
        }

        public static H Empty => new();
    }
}