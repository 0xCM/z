//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    public readonly struct NativeModule<T> : INativeModule<T>
        where T : unmanaged
    {
        public readonly string Name {get;}

        public readonly IntPtr Handle {get;}

        [MethodImpl(Inline)]
        public NativeModule(string name, IntPtr handle)
        {
            Name = name;
            Handle = handle;
        }

        public MemoryAddress Address
        {
            [MethodImpl(Inline)]
            get => Handle;
        }

        public void Dispose()
        {
            if (Handle != IntPtr.Zero)
                Kernel32.FreeLibrary(Handle);
        }

        [MethodImpl(Inline)]
        public string Format()
            => string.Format(RpOps.PSx2, Address, Name);

        [MethodImpl(Inline)]
        public static implicit operator IntPtr(NativeModule<T> src)
            => src.Handle;

        [MethodImpl(Inline)]
        public static implicit operator NativeModule(NativeModule<T> src)
            => new NativeModule(src.Name, src.Handle);
    }
}