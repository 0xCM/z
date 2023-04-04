//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class Alloc : IDisposable
    {
        public static Alloc create() => new Alloc();

        // public static CompositeDispenser composite()
        //     => Dispense.dispenser(() => new CompositeDispenser());

        // public static CompositeDispenser composite(MemoryDispenser memory, StringDispenser strings, LabelDispenser labels, SymbolDispenser symbols, SourceDispenser source)
        //     => Dispense.dispenser(() => new CompositeDispenser(memory, strings, labels, symbols, source));

        // public static NativeSigDispenser sigs()
        //     => Dispense.dispenser(() => new NativeSigDispenser());

        // public static NativeSigDispenser sigs(MemoryDispenser mem, StringDispenser strings, LabelDispenser labels)
        //     => Dispense.dispenser(() => new NativeSigDispenser(mem, strings, labels));

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

        public LabelDispenser Labels(uint capacity = LabelDispenser.DefaultCapacity)
            => (LabelDispenser)Data.GetOrAdd(AllocationKind.Label, k => Dispense.labels(capacity));

        public MemoryDispenser Memory(uint capacity = MemoryDispenser.DefaultCapacity)
            => (MemoryDispenser)Data.GetOrAdd(AllocationKind.Memory, k => Dispense.memory(capacity));

        public PageDispenser Pages(uint pages = SourceDispenser.DefaultCapacity)
            => (PageDispenser)Data.GetOrAdd(AllocationKind.Page, k => Dispense.pages(pages));

        public SourceDispenser Source(uint capacity = SourceDispenser.DefaultCapacity)
            => (SourceDispenser)Data.GetOrAdd(AllocationKind.Source, k => Dispense.source(capacity));

        public StringDispenser Strings(uint capacity = StringDispenser.DefaultCapacity)
            => (StringDispenser)Data.GetOrAdd(AllocationKind.String, k => Dispense.strings(capacity));

        public SymbolDispenser Symbols(uint capacity = SymbolDispenser.DefaultCapacity)
            => (SymbolDispenser)Data.GetOrAdd(AllocationKind.Symbol, k => Dispense.symbols(capacity));

        public CellDispenser<T> Cells<T>(uint count)
            where T : unmanaged
                => (CellDispenser<T>)Data.GetOrAdd(AllocationKind.Cell, k => Dispense.cells<T>(count));

        public Label Label(string content)
            => Labels().Label(content);

        public StringRef String(string content)
            => Strings().String(content);

        public CompositeDispenser Composite()
            => (CompositeDispenser)Data.GetOrAdd(AllocationKind.Composite, k => Dispense.composite(Memory(), Strings(), Labels(), Symbols(), Source()));

        public NativeSigDispenser Sigs()
            => (NativeSigDispenser)Data.GetOrAdd(AllocationKind.NativeSig, k => Dispense.sigs(Memory(), Strings(), Labels()));

        public NativeSigRef Sig(string scope, string name, NativeType ret, params NativeOpDef[] ops)
            => Sigs().Sig(scope, name,ret,ops);

        public NativeSigRef Sig(NativeSigSpec spec)
            => Sigs().Sig(spec);

        public void Dispose()
        {
            iter(Data.Keys, k => Data[k].Dispose());
        }
    }
}