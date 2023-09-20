//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static NativeSigs;

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

        Persistent,
    }

    protected readonly ConcurrentDictionary<AllocationKind,IAllocDispenser> Data = new();

    public LabelDispenser Labels(uint capacity = LabelDispenser.DefaultCapacity)
        => (LabelDispenser)Data.GetOrAdd(AllocationKind.Label, k => Dispense.labels(capacity));

    public MemoryDispenser Memory(uint capacity = MemoryDispenser.DefaultCapacity)
        => (MemoryDispenser)Data.GetOrAdd(AllocationKind.Memory, k => Dispense.memory(capacity));

    public PageDispenser Pages(uint pages = MemoryDispenser.DefaultCapacity)
        => (PageDispenser)Data.GetOrAdd(AllocationKind.Page, k => Dispense.pages(pages));

    public StringDispenser Strings(uint capacity = StringDispenser.DefaultCapacity)
        => (StringDispenser)Data.GetOrAdd(AllocationKind.String, k => Dispense.strings(capacity));

    public SymbolDispenser Symbols(uint capacity = SymbolDispenser.DefaultCapacity)
        => (SymbolDispenser)Data.GetOrAdd(AllocationKind.Symbol, _ => Dispense.symbols(capacity));

    public Label Label(ReadOnlySpan<char> content)
        => Labels().Label(content);

    public StringRef String(ReadOnlySpan<char> content)
        => Strings().String(content);

    public CompositeDispenser Composite()
        => (CompositeDispenser)Data.GetOrAdd(AllocationKind.Composite, 
            _ => Dispense.composite(Memory(), Strings(), Labels(), Symbols()));

    public SigDispenser Sigs()
        => (SigDispenser)Data.GetOrAdd(AllocationKind.NativeSig, 
            _ => Dispense.sigs(Memory(), Strings(), Labels()));

    public NativeSigRef Sig(ReadOnlySpan<char> scope, ReadOnlySpan<char> name, NativeType ret, params Operand[] ops)
        => Sigs().Sig(scope, name,ret,ops);

    public NativeSigRef Sig(NativeSig spec)
        => Sigs().Sig(spec);

    public void Dispose()
    {
        iter(Data.Keys, k => Data[k].Dispose());
    }
}
