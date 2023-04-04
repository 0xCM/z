//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class SourceDispenser : Dispenser<SourceDispenser>, ISourceDispenser
    {
        public const uint DefaultCapacity = Pow2.T12*8;

        readonly Dictionary<long,SourceAllocator> Allocators;

        public SourceDispenser(uint capacity = DefaultCapacity)
            : base(true)
        {
            Allocators = new();
            Allocators[Seq] = SourceAllocator.alloc(DefaultCapacity);
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
                    alloc = SourceAllocator.alloc(DefaultCapacity);
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