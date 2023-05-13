//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class StringDispenser : Dispenser<StringDispenser>, IStringDispenser
    {
        public const uint DefaultCapacity = Pow2.T16;

        readonly Dictionary<long,StringAllocator> Allocators;

        public StringDispenser(uint capacity = DefaultCapacity)
            : base(true)
        {
            Allocators = new();
            Allocators[Seq] = StringAllocator.alloc(DefaultCapacity);
        }

        protected override void Dispose()
        {
            iter(Allocators.Values, a => a.Dispose());
        }

        public StringRef String(ReadOnlySpan<char> content)
        {
            var dst = StringRef.Empty;
            lock(Locker)
            {
                var alloc = Allocators[Seq];
                if(!alloc.Alloc(content, out dst))
                {
                    alloc = StringAllocator.alloc(DefaultCapacity);
                    alloc.Alloc(content, out dst);
                    Allocators[next()] = alloc;
                }
            }
            return dst;
        }
   }
}