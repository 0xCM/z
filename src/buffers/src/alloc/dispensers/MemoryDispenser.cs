//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public class MemoryDispenser : Dispenser<MemoryDispenser>, IMemoryDispenser
{
    public const uint DefaultCapacity = Pow2.T12*16;

    readonly Dictionary<long,MemAllocator> Allocators;

    internal MemoryDispenser(uint capacity = DefaultCapacity)
        : base(true)
    {
        Allocators = new();
        Allocators[Seq] = MemAllocator.alloc(DefaultCapacity);
    }

    protected override void Dispose()
    {
        sys.iter(Allocators.Values, a => a.Dispose());
    }

    public MemorySegment Memory(ByteSize size)
    {
        var dst = MemorySegment.Empty;
        lock(Locker)
        {
            var allocator = Allocators[Seq];
            if(!allocator.Alloc(size, out dst))
            {
                if(size < DefaultCapacity)
                    allocator = MemAllocator.alloc(DefaultCapacity);
                else
                    allocator = MemAllocator.alloc(size);

                allocator.Alloc(size, out dst);
                Allocators[next()] = allocator;
            }
        }
        return dst;
    }
}
