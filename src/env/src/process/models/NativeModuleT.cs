//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using Windows;

public readonly struct NativeModule<T> : INativeModule<T>
    where T : unmanaged
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

    public MemoryAddress Address
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
        => string.Format(RP.PSx2, Address, Name);

    [MethodImpl(Inline)]
    public static implicit operator IntPtr(NativeModule<T> src)
        => src.Handle;

    [MethodImpl(Inline)]
    public static implicit operator NativeModule(NativeModule<T> src)
        => new (src.Name, src.Handle);
}
