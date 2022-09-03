//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    public class SymbolDispenser : Dispenser<SymbolDispenser>, ISymbolDispenser
    {
        const uint Capacity = MemoryPage.PageSize;

        readonly Dictionary<long,LabelAllocator> Allocators;

        public SymbolDispenser(uint capacity = Capacity)
            : base(true)
        {
            Allocators = new();
            Allocators[Seq] = LabelAllocator.alloc(Capacity);
        }

        protected override void Dispose()
        {
            iter(Allocators.Values, a => a.Dispose());
        }

        Label DispenseLabel(string content)
        {
            var label = Label.Empty;
            lock(Locker)
            {
                var allocator = Allocators[Seq];
                if(!allocator.Alloc(content, out label))
                {
                    allocator = LabelAllocator.alloc(Capacity);
                    allocator.Alloc(content, out label);
                    Allocators[next()] = allocator;
                }
            }
            return label;
        }

        public LocatedSymbol Symbol(MemoryAddress location, string name)
            => Symbol(new SymAddress(0,location), name);

        public LocatedSymbol Symbol(SymAddress location, string name)
            => new LocatedSymbol(location, DispenseLabel(name));
    }
}