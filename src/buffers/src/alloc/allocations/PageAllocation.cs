//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class PageAllocation : Allocation<MemorySegment>
    {
        public const uint PageSize = Pow2.T12;

        public static PageAllocation alloc(uint pages)
            => new (pages);

        readonly NativeBuffer Buffer;

        public uint PageCount {get;}

        PageAllocation(uint pages)
        {
            PageCount = pages;
            Buffer = NativeBuffers.alloc(PageSize*PageCount);
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

        protected override Span<MemorySegment> Data
        {
            [MethodImpl(Inline)]
            get => cover<MemorySegment>(BaseAddress, PageCount);
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
            => sys.address(first(page(src,index)));

        static Index<MemorySegment> segments(NativeBuffer src, uint count)
        {
            var dst = sys.alloc<MemorySegment>(count);
            for(var i=0u; i<count; i++)
            {
                var a = address(src,i);
                seek(dst,i) = new MemorySegment(address(src,i), PageSize);
            }
            return dst;
        }
    }
}