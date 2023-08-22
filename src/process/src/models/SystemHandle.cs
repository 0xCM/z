//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using Windows;

public readonly struct SystemHandle : IDisposable
{
    [MethodImpl(Inline)]
    public static SystemHandle own(IntPtr src)
        => new SystemHandle(src);

    public IntPtr Handle {get;}

    [MethodImpl(Inline)]
    public SystemHandle(IntPtr value)
    {
        Handle = value;
    }

    public MemoryAddress Address
    {
        [MethodImpl(Inline)]
        get => Handle;
    }

    public void Dispose()
    {
        if(IsNonEmpty)
            Kernel32.CloseHandle(Handle);
    }

    public bool IsEmpty
    {
        [MethodImpl(Inline)]
        get => (ulong)Handle == 0;
    }

    public bool IsNonEmpty
    {
        [MethodImpl(Inline)]
        get => (ulong)Handle != 0;
    }

    public string Format()
        => Address.Format();

    public override string ToString()
        => Format();

    [MethodImpl(Inline)]
    public unsafe T* Pointer<T>()
        where T : unmanaged 
            => Address.Pointer<T>();

    [MethodImpl(Inline)]
    public static implicit operator IntPtr(SystemHandle src)
        => src.Handle;

    [MethodImpl(Inline)]
    public static implicit operator SystemHandle(IntPtr src)
        => new SystemHandle(src);
}
