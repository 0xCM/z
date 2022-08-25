//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class MemoryBlocks : Seq<MemoryBlocks, MemoryBlock>
    {
        public static MemoryList<T> list<T>(uint count)
            where T : unmanaged
                => new MemoryList<T>(memory.native(count*Sized.size<T>()));

        public static unsafe MemoryBlock block(byte* pSrc, ByteSize size)
        {
            var slice = MemorySpan.create(pSrc,size);
            return new MemoryBlock(slice.Origin, slice.Edit.ToArray());
        }

        public MemoryBlocks()
        {


        }
        [MethodImpl(Inline)]
        public MemoryBlocks(MemoryBlock[] src)
            : base(src)
        {
            
        }

        public MemoryBlocks Sort()
        {
            Data.Sort();
            return this;
        }

        [MethodImpl(Inline)]
        public static implicit operator MemoryBlocks(MemoryBlock[] src)
            => new MemoryBlocks(src);
    }
}