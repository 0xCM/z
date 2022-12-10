//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class Alloc : IDisposable
    {
        enum AllocationKind : byte
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

        public static Alloc create()
            => new Alloc();

        public static CompositeDispenser asm()
            => new CompositeDispenser();

        ConcurrentDictionary<AllocationKind,IAllocDispenser> Data;

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

        public CellDispenser<T> Cells<T>(uint partition)
            where T : unmanaged
                => (CellDispenser<T>)Data.GetOrAdd(AllocationKind.Cell, k => Dispense.cels<T>(partition));

        public CompositeDispenser Composite()
            => (CompositeDispenser)Data.GetOrAdd(AllocationKind.Composite, k => Dispense.composite(Memory(), Strings(), Labels(), Symbols(), Source()));

        public NativeSigDispenser Sigs()
            => (NativeSigDispenser)Data.GetOrAdd(AllocationKind.NativeSig, k => Dispense.sigs(Memory(), Strings(), Labels()));

        public Alloc()
        {
            Data = new();
        }

        public void Dispose()
        {
            iter(Data.Keys, k => Data[k].Dispose());
        }

        public Label Label(string content)
            => Labels().Label(content);

        public NativeSigRef Sig(string scope, string name, NativeType ret, params NativeOpDef[] ops)
            => Sigs().Sig(scope, name,ret,ops);

        public NativeSigRef Sig(NativeSigSpec spec)
            => Sigs().Sig(spec);

        public StringRef String(string content)
            => Strings().String(content);
    }
}