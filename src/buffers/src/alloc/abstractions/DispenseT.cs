//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public abstract class Dispense<T>
        where T : Dispense<T>, new()
    {
        static ConcurrentDictionary<uint,IAllocDispenser> Dispensed = new();

        static uint Seq;

        public static LabelDispenser labels(uint capacity = LabelDispenser.DefaultCapacity)
            => dispenser(() => new LabelDispenser());

        public static MemoryDispenser memory(uint capacity = MemoryDispenser.DefaultCapacity)
            => dispenser(() => new MemoryDispenser(capacity));

        public static CompositeDispenser composite()
            => dispenser(() => new CompositeDispenser());

        public static CompositeDispenser composite(MemoryDispenser memory, StringDispenser strings, LabelDispenser labels, SymbolDispenser symbols, SourceDispenser source)
            => dispenser(() => new CompositeDispenser(memory, strings, labels, symbols, source));

        public static SourceDispenser source(uint capacity = SourceDispenser.DefaultCapacity)
            => dispenser(() => new SourceDispenser(capacity));

        public static SymbolDispenser symbols(uint capacity = SymbolDispenser.DefaultCapacity)
            => dispenser(() => new SymbolDispenser());

        public static CellDispenser<C> cells<C>(uint count)
            where C : unmanaged
                => dispenser(() => new CellDispenser<C>(count));

        public static StringDispenser strings(uint capacity = StringDispenser.DefaultCapacity)
            => dispenser(() => new StringDispenser(capacity));

        public static PageDispenser pages(uint count = PageDispenser.DefaultPageCount)
            => dispenser(() => new PageDispenser(count));

        public static NativeSigDispenser sigs()
            => dispenser(() => new NativeSigDispenser());

        public static NativeSigDispenser sigs(MemoryDispenser mem, StringDispenser strings, LabelDispenser labels)
            => dispenser(() => new NativeSigDispenser(mem, strings));

        public static D dispenser<D>(Func<D> f)
            where D : IAllocDispenser
        {
            var dispensed = f();
            Dispensed.TryAdd(inc(ref Seq), dispensed);
            return dispensed;
        }
    }
}