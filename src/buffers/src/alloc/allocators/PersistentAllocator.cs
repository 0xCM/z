//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class PersistentAllocator : IBufferAllocator<PersistentMemory>
    {
        readonly IMemDb Db;

        public readonly ByteSize SegmentSize;

        readonly List<PersistentMemory> Allocations = new();

        internal PersistentAllocator(IMemDb db, ByteSize? segsize = null)
        {
            Db = db;
            SegmentSize = segsize ?? Pow2.T18;
        }
        
        public MemoryAddress BaseAddress 
            => Db.BaseAddress;

        public ByteSize Size 
            => Db.Size;

        public bool Alloc(ByteSize size, out PersistentMemory dst)
        {
            dst = new(Db.Reserve(size));
            var result = dst.IsNonEmpty;
            if(result)
                Allocations.Add(dst);
            return result;
        }

        public void Store<T>(AllocToken token, ReadOnlySpan<T> src)
            where T : unmanaged
                => Db.Store(token, src);

        // public bool Alloc(ByteSize size, out PersistentMemory dst)
        //     => Alloc(Guid.NewGuid().ToString(), size, out dst);

        public bool Alloc(out PersistentMemory dst)
            => Alloc(SegmentSize, out dst);

        public void Dispose()
        {

        }
    }
}