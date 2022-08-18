//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class PageDispenser : Dispenser<PageDispenser>, IPageDispenser
    {
        readonly Dictionary<long,IPageAllocator> Allocators;

        object locker;

        const uint Capacity = 64;

        static ByteSize PageSize => PageBlocks.PageSize;

        internal PageDispenser(uint capacity = Capacity)
            : base(true)
        {
            Allocators = new();
            locker = new();
            Allocators[Seq] = PageAllocator.alloc(Capacity);
        }

        public MemorySeg Page()
        {
            var address = MemoryAddress.Zero;
            lock(locker)
            {
                address = Allocators[Seq].Alloc();
                if(address == 0)
                {
                    var allocator = PageAllocator.alloc(Capacity);
                    Allocators[next()] = allocator;
                    address = allocator.Alloc();
                }
            }
            return new MemorySeg(address, PageSize);
        }

        protected override void Dispose()
            => core.iter(Allocators.Values, a => a.Dispose());
    }
}