//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class LabelDispenser : Dispenser<LabelDispenser>, ILabelDispenser
    {
        const uint Capacity = MemoryPage.PageSize;

        readonly Dictionary<long,LabelAllocator> Allocators;

        internal LabelDispenser(uint capacity = Capacity)
            : base(true)
        {
            Allocators = new();
            Allocators[Seq] = LabelAllocator.alloc(Capacity);
        }

        public Label Label(string content)
        {
            var label = Z0.Label.Empty;
            lock(Locker)
            {
                var alloc = Allocators[Seq];
                if(!alloc.Alloc(content, out label))
                {
                    alloc = LabelAllocator.alloc(Capacity);
                    alloc.Alloc(content, out label);
                    Allocators[next()] = alloc;
                }
            }
            return label;
        }

        protected override void Dispose()
            => iter(Allocators.Values, a => a.Dispose());
    }
}