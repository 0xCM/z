//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class PageAllocation : Allocation<MemorySeg>
    {
        public const uint PageSize = MemoryPage.PageSize;

        public static PageAllocation alloc(uint pages)
            => new PageAllocation(pages);

        readonly NativeBuffer Buffer;

        public uint PageCount {get;}

        PageAllocation(uint pages)
        {
            PageCount = pages;
            Buffer = memory.native(PageSize*PageCount);
        }


        protected override void Dispose()
        {
            Buffer.Dispose();
        }

        public override MemoryAddress BaseAddress
        {
            [MethodImpl(Inline)]
            get => Buffer.BaseAddress;
        }

        public override ByteSize Size
        {
            [MethodImpl(Inline)]
            get => Buffer.Size;
        }

        public BitWidth Width
        {
            [MethodImpl(Inline)]
            get => Buffer.Width;
        }

        protected override Span<MemorySeg> Data
        {
            [MethodImpl(Inline)]
            get => cover<MemorySeg>(BaseAddress, PageCount);
        }

        [MethodImpl(Inline)]
        public Span<byte> PageBuffer(uint index)
            => page(Buffer,index);

        [MethodImpl(Inline)]
        public MemoryAddress PageAddress(uint index)
            => address(Buffer,index);

        [MethodImpl(Inline)]
        static Span<byte> page(NativeBuffer src,  uint index)
            => slice(src.Edit, index*PageSize, PageSize);

        [MethodImpl(Inline)]
        static MemoryAddress address(NativeBuffer src,  uint index)
            => core.address(first(page(src,index)));

        static Index<MemorySeg> segments(NativeBuffer src, uint count)
        {
            var dst = sys.alloc<MemorySeg>(count);
            for(var i=0u; i<count; i++)
            {
                var a = address(src,i);
                seek(dst,i) = new MemorySeg(address(src,i), PageSize);
            }
            return dst;
        }
    }
}