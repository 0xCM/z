//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

public unsafe class PageAllocator : IPageAllocator
{
    public static PageAllocator alloc(uint count)
        => new (count);

    readonly NativeBuffer Buffer;

    readonly Index<int> Allocations;

    public uint PageCount {get;}

    public MemoryAddress BaseAddress
    {
        [MethodImpl(Inline)]
        get => Buffer.BaseAddress;
    }

    public ByteSize Size
    {
        [MethodImpl(Inline)]
        get => Buffer.Size;
    }

    public BitWidth Width
    {
        [MethodImpl(Inline)]
        get => Buffer.Width;
    }

    internal PageAllocator(uint pages)
    {
        PageCount = pages;
        Buffer = NativeBuffers.alloc(PageSize*PageCount);
        Allocations = sys.alloc<int>(PageCount);
        for(var i=0; i<PageCount; i++)
            Allocations[i] = -1;
    }

    [MethodImpl(Inline)]
    static Span<byte> page(NativeBuffer src,  uint index)
        => slice(src.Edit, index*PageSize, PageSize);

    [MethodImpl(Inline)]
    static MemoryAddress address(NativeBuffer src,  uint index)
        => sys.address(first(page(src,index)));

    [MethodImpl(Inline)]
    MemoryAddress PageAddress(uint index)
        => address(Buffer, index);

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

    protected Span<MemoryAddress> Data
    {
        [MethodImpl(Inline)]
        get => cover<MemoryAddress>(BaseAddress, PageCount);
    }

    public void Dispose()
    {
        (Buffer as IDisposable).Dispose();
    }
}
