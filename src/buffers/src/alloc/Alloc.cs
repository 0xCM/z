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
            => (SymbolDispenser)Data.GetOrAdd(AllocationKind.Symbol, 
                    _ => Dispense.symbols(capacity));

        public CellDispenser<T> Cells<T>(uint count)
            where T : unmanaged
                => (CellDispenser<T>)Data.GetOrAdd(AllocationKind.Cell,
                     _ => Dispense.cells<T>(count));

        public Label Label(string content)
            => Labels().Label(content);

        public StringRef String(string content)
            => Strings().String(content);

        public CompositeDispenser Composite()
            => (CompositeDispenser)Data.GetOrAdd(AllocationKind.Composite, 
                _ => Dispense.composite(Memory(), Strings(), Labels(), Symbols(), Source()));

        public NativeSigDispenser Sigs()
            => (NativeSigDispenser)Data.GetOrAdd(AllocationKind.NativeSig, 
                _ => Dispense.sigs(Memory(), Strings(), Labels()));

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