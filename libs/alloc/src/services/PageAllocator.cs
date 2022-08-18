//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    public unsafe class PageAllocator : Allocation<MemoryAddress>, IPageAllocator
    {
        public static PageAllocator alloc(uint count)
            => new PageAllocator(count);

        PageAllocation Memory;

        Index<int> Allocations;

        public uint PageCount {get;}

        public override MemoryAddress BaseAddress
        {
            [MethodImpl(Inline)]
            get => Memory.BaseAddress;
        }

        public override ByteSize Size
        {
            [MethodImpl(Inline)]
            get => Memory.Size;
        }

        public BitWidth Width
        {
            [MethodImpl(Inline)]
            get => Memory.Width;
        }

        internal PageAllocator(uint pages)
        {
            PageCount = pages;
            Memory = PageAllocation.alloc(PageCount);
            Allocations = sys.alloc<int>(PageCount);
            for(var i=0; i<PageCount; i++)
                Allocations[i] = -1;
        }

        [MethodImpl(Inline)]
        MemoryAddress PageAddress(uint index)
            => Memory.PageAddress(index);

        [MethodImpl(Inline)]
        public MemoryAddress Alloc()
        {
            for(var i=0u; i<PageCount; i++)
            {
                if(Allocations[i] < 0)
                {
                    Allocations[i] = (int)i;
                    return PageAddress(i);
                }
            }
            return MemoryAddress.Zero;
        }

        protected override Span<MemoryAddress> Data
        {
            [MethodImpl(Inline)]
            get => cover<MemoryAddress>(BaseAddress, PageCount);
        }

        public void Free(MemoryAddress src)
        {
            for(var i=0u; i<PageCount; i++)
            {
                ref readonly var index = ref Allocations[i];
                if(Allocations[i] > 0 && PageAddress(i) == src)
                    Allocations[i] = -1;
            }
        }

        protected override void Dispose()
        {
            (Memory as IDisposable).Dispose();
        }
    }
}