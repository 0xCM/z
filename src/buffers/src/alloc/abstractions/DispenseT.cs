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

        public static CellDispenser<C> cells<C>(uint partition)
            where C : unmanaged
                => dispenser(() => new CellDispenser<C>(partition));

        public static StringDispenser strings()
            => dispenser(() => new StringDispenser());

        public static StringDispenser strings(ByteSize capacity)
            => dispenser(() => new StringDispenser(capacity));

        public static PageDispenser pages()
            => dispenser(() => new PageDispenser());

        public static PageDispenser pages(uint count)
            => dispenser(() => new PageDispenser(count));


        public static D dispenser<D>(Func<D> f)
            where D : IAllocDispenser
        {
            var dispensed = f();
            Dispensed.TryAdd(inc(ref Seq), dispensed);
            return dispensed;
        }
    }
}