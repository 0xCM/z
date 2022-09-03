//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Pins an existing array
    /// </summary>
    public unsafe struct PinnedArray<T> : IDisposable
        where T : unmanaged
    {
        readonly object Data;

        readonly PinnedPtr<T> Pin;

        public PinnedArray(T[] src)
        {
            var handle = GCHandle.Alloc(src, GCHandleType.Pinned);
            Pin = new PinnedPtr<T>(src, handle, (T*)handle.AddrOfPinnedObject().ToPointer());
            Data = src;
        }

        public void Dispose()
        {
            Pin.Dispose();
        }

        [MethodImpl(Inline)]
        public Ptr<T> Pointer()
            => new Ptr<T>(Pin.Pointer);
    }
}