//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class SourceDispenser : Dispenser<SourceDispenser>, ISourceDispenser
    {
        const uint Capacity = MemoryPage.PageSize*8;

        readonly Dictionary<long,SourceAllocator> Allocators;

        internal SourceDispenser(uint capacity = Capacity)
            : base(true)
        {
            Allocators = new();
            Allocators[Seq] = SourceAllocator.alloc(Capacity);
        }

        protected override void Dispose()
        {
            iter(Allocators.Values, a => a.Dispose());
        }

        public SourceText Source(string src)
        {
            var dst = SourceText.Empty;
            lock(Locker)
            {
                var alloc = Allocators[Seq];
                if(!alloc.Alloc(src, out dst))
                {
                    alloc = SourceAllocator.alloc(Capacity);
                    alloc.Alloc(src, out dst);
                    Allocators[next()] = alloc;
                }
            }
            return dst;
        }

        public SourceText Source(ReadOnlySpan<string> src)
        {
            var dst = text.buffer();
            iter(src, x => dst.AppendLine(x));
            return Source(dst.Emit());
        }
   }
}