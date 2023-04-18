//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    public readonly struct NativeModule : INativeModule
    {
        public readonly string Name {get;}

        public readonly IntPtr Handle {get;}

        public readonly bool Owner {get;}

        [MethodImpl(Inline)]
        public NativeModule(string name, IntPtr handle, bool owner = true)
        {
            Name = name;
            Handle = handle;
            Owner = owner;
        }

        [MethodImpl(Inline)]
        public MemoryAddress ProcAddress(string name)
            => NativeModules.procaddress(this,name);

        [MethodImpl(Inline)]
        public D Proc<D>(string name)
            where D : Delegate
                => NativeModules.proc<D>(this, name);

        public MemoryAddress BaseAddress
        {
            [MethodImpl(Inline)]
            get => Handle;
        }

        public void Dispose()
        {
            if (Handle != IntPtr.Zero && Owner)
                Kernel32.FreeLibrary(Handle);
        }

        [MethodImpl(Inline)]
        public string Format()
            => string.Format(RP.PSx2, BaseAddress, Name);

        [MethodImpl(Inline)]
        public static implicit operator IntPtr(NativeModule src)
            => src.Handle;
    }
}