//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public unsafe readonly struct PinnedPtr<T> : IDisposable
    where T : unmanaged
{
    readonly object Origin;

    readonly GCHandle Handle;

    public readonly T* Pointer;

    [MethodImpl(Inline)]
    internal PinnedPtr(object origin, GCHandle handle, T* ptr)
    {
        Origin = origin;
        Handle = handle;
        Pointer = ptr;
    }

    public ref T First
    {
        [MethodImpl(Inline)]
        get => ref Pointer[0];
    }

    public ref T this[uint index]
    {
        [MethodImpl(Inline)]
        get => ref Pointer[index];
    }

    public ref T this[int index]
    {
        [MethodImpl(Inline)]
        get => ref Pointer[index];
    }

    public void Dispose()
    {
        if(Handle.IsAllocated)
            Handle.Free();
    }

    public bool IsEmpty
    {
        [MethodImpl(Inline)]
        get => !Handle.IsAllocated;
    }

    public bool IsNonEmpty
    {
        [MethodImpl(Inline)]
        get => Handle.IsAllocated;
    }

    public static PinnedPtr<T> Empty
    {
        [MethodImpl(Inline)]
        get => new PinnedPtr<T>(null, default, null);
    }
}
