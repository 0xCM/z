//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class StringDispenser : Dispenser<StringDispenser>, IStringDispenser
    {
        const uint Capacity = Pow2.T12;

        readonly Dictionary<long,StringAllocator> Allocators;

        public StringDispenser(uint capacity = Capacity)
            : base(true)
        {
            Allocators = new();
            Allocators[Seq] = StringAllocator.alloc(Capacity);
        }

        protected override void Dispose()
        {
            iter(Allocators.Values, a => a.Dispose());
        }

        public StringRef String(string content)
        {
            var dst = StringRef.Empty;
            lock(Locker)
            {
                var alloc = Allocators[Seq];
                if(!alloc.Alloc(content, out dst))
                {
                    alloc = StringAllocator.alloc(Capacity);
                    alloc.Alloc(content, out dst);
                    Allocators[next()] = alloc;
                }
            }
            return dst;
        }
   }
}