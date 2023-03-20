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

        public CellDispenser<T> Cells<T>(uint partition)
            where T : unmanaged
                => (CellDispenser<T>)Data.GetOrAdd(AllocationKind.Cell, k => Dispense.cells<T>(partition));

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