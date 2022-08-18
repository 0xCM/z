//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    /// <summary>
    /// Defines a uniform structural representation for so-called 'handles'
    /// </summary>
    public readonly ref struct SystemHandle<T>
        where T : struct, ISystemHandle
    {
        public T Value {get;}

        [MethodImpl(Inline)]
        public SystemHandle(T subject)
            => Value = subject;

        public void Dispose()
        {
            if(IsOwner)
                Kernel32.CloseHandle(Address);
        }

        public MemoryAddress Address
        {
            [MethodImpl(Inline)]
            get => Value.Address;
        }

        public bool IsOwner
        {
            [MethodImpl(Inline)]
            get => Value.IsOwner;
        }

        [MethodImpl(Inline)]
        public static implicit operator SystemHandle<T>(T src)
            => new SystemHandle<T>(src);
    }
}