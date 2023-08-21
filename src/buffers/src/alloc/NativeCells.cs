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
            where T : unmanaged
        {
            id = inc(ref Allocation);
            var sz = count * size<T>();
            var buffer = NativeBuffers.alloc(sz);
            Allocations.TryAdd(id,buffer);
            return new NativeCells<T>(id, buffer.BaseAddress, size<T>(), count);
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