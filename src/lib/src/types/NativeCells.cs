//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public sealed class NativeCells
    {
        public static NativeCells<T> alloc<T>(uint count, out long id)
        {
            id = inc(ref Allocation);
            var sz = count * size<NativeCell<T>>();
            var buffer = memory.native(sz);
            Allocations.TryAdd(id,buffer);
            return new NativeCells<T>(id, buffer.BaseAddress, size<NativeCell<T>>(), count);
        }

        internal static void free(long id)
        {
            if(Allocations.TryRemove(id, out var buffer))
                buffer.Dispose();
        }

        static long Allocation;

        static ConcurrentDictionary<long,NativeBuffer> Allocations;

        static NativeCells()
        {
            Allocation = 0;
            Allocations = new();
        }
    }
}