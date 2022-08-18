//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    unsafe partial struct memory
    {
        [Op, Closures(Closure)]
        public static PinnedPtr<T> pin<T>(object src)
            where T : unmanaged
        {
            var handle = GCHandle.Alloc(src, GCHandleType.Pinned);
            var data = (T*)handle.AddrOfPinnedObject().ToPointer();
            return new PinnedPtr<T>(src, handle, data);
        }

        [Op, Closures(Closure)]
        public static PinnedPtr pin(object src)
        {
            var handle = GCHandle.Alloc(src, GCHandleType.Pinned);
            var data = handle.AddrOfPinnedObject().ToPointer();
            return new PinnedPtr(src, handle, data);
        }
    }
}