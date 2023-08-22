//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public unsafe readonly struct PinnedPtr : IDisposable
{
    readonly object Origin;

    readonly GCHandle Handle;

    readonly void* Pointer;

    [MethodImpl(Inline)]
    internal PinnedPtr(object origin, GCHandle handle, void* ptr)
    {
        Origin = origin;
        Handle = handle;
        Pointer = ptr;
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

    public static PinnedPtr Empty
    {
        [MethodImpl(Inline)]
        get => new PinnedPtr(null, default, null);
    }
}
