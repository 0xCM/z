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
            => string.Format(RP.PSx2, Address, Name);

        [MethodImpl(Inline)]
        public static implicit operator IntPtr(NativeModule src)
            => src.Handle;
    }
}