//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public unsafe class Pins
    {        
        const NumericKind Closure = UnsignedInts;
        
        public static PinnedIndex<T> index<T>(T src)
            where T : unmanaged, IIndex<T>
                => new PinnedIndex<T>(src.Storage);

        public static PinnedArray<T> array<T>(T[] src)
            where T : unmanaged
                => new PinnedArray<T>(src);

        [Op, Closures(Closure)]
        public static PinnedPtr<T> pointer<T>(object src)
            where T : unmanaged
        {
            var handle = GCHandle.Alloc(src, GCHandleType.Pinned);
            var data = (T*)handle.AddrOfPinnedObject().ToPointer();
            return new PinnedPtr<T>(src, handle, data);
        }

        [Op, Closures(Closure)]
        public static PinnedPtr pointer(object src)
        {
            var handle = GCHandle.Alloc(src, GCHandleType.Pinned);
            var data = handle.AddrOfPinnedObject().ToPointer();
            return new PinnedPtr(src, handle, data);
        }
    }
}