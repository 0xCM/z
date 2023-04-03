//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class Alloc : IDisposable
    {
        public Alloc create() => new Alloc();

        public static CompositeDispenser composite()
            => Dispense.dispenser(() => new CompositeDispenser());

        public static CompositeDispenser composite(MemoryDispenser memory, StringDispenser strings, LabelDispenser labels, SymbolDispenser symbols, SourceDispenser source)
            => Dispense.dispenser(() => new CompositeDispenser(memory, strings, labels, symbols, source));

        public static NativeSigDispenser sigs()
            => Dispense.dispenser(() => new NativeSigDispenser());

        public static NativeSigDispenser sigs(MemoryDispenser mem, StringDispenser strings, LabelDispenser labels)
            => Dispense.dispenser(() => new NativeSigDispenser(mem, strings, labels));

        protected enum AllocationKind : byte
        {
            Label,

            String,

            Memory,

            Page,

            Source,

            Symbol,

            NativeSig,

            Composite,

            Cell,
        }

        protected ConcurrentDictionary<AllocationKind,IAllocDispenser> Data = new();

        public LabelDispenser Labels()
            => (LabelDispenser)Data.GetOrAdd(AllocationKind.Label, k => Dispense.labels());

        public MemoryDispenser Memory()
            => (MemoryDispenser)Data.GetOrAdd(AllocationKind.Memory, k => Dispense.memory());

        public PageDispenser Pages()
            => (PageDispenser)Data.GetOrAdd(AllocationKind.Page, k => Dispense.pages());

        public SourceDispenser Source()
            => (SourceDispenser)Data.GetOrAdd(AllocationKind.Source, k => Dispense.source());

        public StringDispenser Strings()
            => (StringDispenser)Data.GetOrAdd(AllocationKind.String, k => Dispense.strings());

        public SymbolDispenser Symbols()
            => (SymbolDispenser)Data.GetOrAdd(AllocationKind.Symbol, k => Dispense.symbols());

        public CellDispenser<T> Cells<T>(uint count)
            where T : unmanaged
                => (CellDispenser<T>)Data.GetOrAdd(AllocationKind.Cell, k => Dispense.cells<T>(count));

        public Label Label(string content)
            => Labels().Label(content);

        public StringRef String(string content)
            => Strings().String(content);

        public void Dispose()
        {
            iter(Data.Keys, k => Data[k].Dispose());
        }
    }
}