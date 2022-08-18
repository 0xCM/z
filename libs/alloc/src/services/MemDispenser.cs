//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class MemoryDispenser : Dispenser<MemoryDispenser>, IMemoryDispenser
    {
        const uint Capacity = MemoryPage.PageSize*16;

        readonly Dictionary<long,MemAllocator> Allocators;

        internal MemoryDispenser(uint capacity = Capacity)
            : base(true)
        {
            Allocators = new();
            Allocators[Seq] = MemAllocator.alloc(Capacity);
        }

        protected override void Dispose()
        {
            sys.iter(Allocators.Values, a => a.Dispose());
        }

        public MemorySeg Memory(ByteSize size)
        {
            var dst = MemorySeg.Empty;
            lock(Locker)
            {
                var allocator = Allocators[Seq];
                if(!allocator.Alloc(size, out dst))
                {
                    if(size < Capacity)
                        allocator = MemAllocator.alloc(Capacity);
                    else
                        allocator = MemAllocator.alloc(size);

                    allocator.Alloc(size, out dst);
                    Allocators[next()] = allocator;
                }
            }
            return dst;
        }
    }
}