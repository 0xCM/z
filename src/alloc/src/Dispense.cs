//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class Dispense
    {
        public static D dispenser<D>(Func<D> f)
            where D : IAllocDispenser
        {
            var dispensed = f();
            Dispensed.TryAdd(inc(ref Seq), dispensed);
            return dispensed;
        }

        public static CompositeDispenser composite()
            => dispenser(() => new CompositeDispenser());

        public static CompositeDispenser composite(MemoryDispenser memory, StringDispenser strings, LabelDispenser labels, SymbolDispenser symbols, SourceDispenser source)
            => dispenser(() => new CompositeDispenser(memory, strings, labels, symbols, source));

        public static NativeSigDispenser sigs()
            => dispenser(() => new NativeSigDispenser());

        public static NativeSigDispenser sigs(MemoryDispenser mem, StringDispenser strings, LabelDispenser labels)
            => dispenser(() => new NativeSigDispenser(mem, strings, labels));

        public static LabelDispenser labels(ByteSize capacity)
            => dispenser(() => new LabelDispenser(capacity));

        public static LabelDispenser labels()
            => dispenser(() => new LabelDispenser());

        public static MemoryDispenser memory()
            => dispenser(() => new MemoryDispenser());

        public static MemoryDispenser memory(ByteSize capacity)
            => dispenser(() => new MemoryDispenser(capacity));

        public static SourceDispenser source(ByteSize capacity)
            => dispenser(() => new SourceDispenser(capacity));

        public static SourceDispenser source()
            => dispenser(() => new SourceDispenser());

        public static SymbolDispenser symbols(ByteSize capacity)
            => dispenser(() => new SymbolDispenser(capacity));

        public static SymbolDispenser symbols()
            => dispenser(() => new SymbolDispenser());

        public static CellDispenser<T> cels<T>(uint partition)
            where T : unmanaged
                => dispenser(() => new CellDispenser<T>(partition));

        public static StringDispenser strings()
            => dispenser(() => new StringDispenser());

        public static StringDispenser strings(ByteSize capacity)
            => dispenser(() => new StringDispenser(capacity));

        public static PageDispenser pages()
            => dispenser(() => new PageDispenser());

        public static PageDispenser pages(uint count)
            => dispenser(() => new PageDispenser(count));

        static ConcurrentDictionary<uint,IAllocDispenser> Dispensed = new();

        static uint Seq;
    }
}