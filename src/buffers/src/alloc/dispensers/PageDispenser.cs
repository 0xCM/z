//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public class PageDispenser : Dispenser<PageDispenser>, IPageDispenser
{
    readonly Dictionary<long,IPageAllocator> Allocators;
    
    object locker;

    public const uint DefaultPageCount = 64;

    static ByteSize PageSize => Pow2.T12;

    public PageDispenser(uint capacity = DefaultPageCount)
        : base(true)
    {
        Allocators = new();
        locker = new();
        Allocators[Seq] = PageAllocator.alloc(DefaultPageCount);
    }

    public MemorySegment Page()
    {
        var address = MemoryAddress.Zero;
        lock(locker)
        {
            address = Allocators[Seq].Alloc();
            if(address == 0u)
            {
                var allocator = PageAllocator.alloc(DefaultPageCount);
                Allocators[next()] = allocator;
                address = allocator.Alloc();
            }
        }
        return new MemorySegment(address, PageSize);
    }

    protected override void Dispose()
        => sys.iter(Allocators.Values, a => a.Dispose());
}
