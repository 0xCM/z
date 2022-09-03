//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Spans;
    using static Arrays;

    /// <summary>
    /// Owns a sequence of <see cref='StringRef'/> allocations
    /// </summary>
    public sealed class StringAllocation : Allocation<StringRef>
    {
        public static StringAllocation alloc(ReadOnlySpan<string> src)
        {
            var count = src.Length;
            var total = 0u;
            for(var i=0; i<count; i++)
                total += (uint)skip(src,i).Length;
            var storage = StringBuffers.buffer(total);
            var allocator = StringAllocator.cover(storage);
            var dst = sys.alloc<StringRef>(count);
            for(var i=0; i<count; i++)
                allocator.Alloc(skip(src,i), out seek(dst,i));
            return new StringAllocation(allocator, dst);
        }

        readonly Index<StringRef> Storage;

        readonly IBufferAllocator Allocator;

        public StringAllocation(IBufferAllocator allocator, StringRef[] allocated)
        {
            Allocator = allocator;
            Storage = allocated;
        }

        public override MemoryAddress BaseAddress
        {
            [MethodImpl(Inline)]
            get => Allocator.BaseAddress;
        }

        protected override Span<StringRef> Data
        {
            [MethodImpl(Inline)]
            get => Storage;
        }

        public override ByteSize Size
        {
            [MethodImpl(Inline)]
            get => Allocator.Size;
        }

        protected override void Dispose()
        {
            Allocator.Dispose();
        }
    }
}