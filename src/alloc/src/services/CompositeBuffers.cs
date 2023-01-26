//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CompositeBuffers : Alloc
    {
        public new static CompositeBuffers create()
            => new CompositeBuffers();

        public static CompositeDispenser composite()
            => Dispense.dispenser(() => new CompositeDispenser());

        public static CompositeDispenser composite(MemoryDispenser memory, StringDispenser strings, LabelDispenser labels, SymbolDispenser symbols, SourceDispenser source)
            => Dispense.dispenser(() => new CompositeDispenser(memory, strings, labels, symbols, source));

        public static NativeSigDispenser sigs()
            => Dispense.dispenser(() => new NativeSigDispenser());

        public static NativeSigDispenser sigs(MemoryDispenser mem, StringDispenser strings, LabelDispenser labels)
            => Dispense.dispenser(() => new NativeSigDispenser(mem, strings, labels));

        public CompositeDispenser Composite()
            => (CompositeDispenser)Data.GetOrAdd(AllocationKind.Composite, k => composite(Memory(), Strings(), Labels(), Symbols(), Source()));

        public NativeSigDispenser Sigs()
            => (NativeSigDispenser)Data.GetOrAdd(AllocationKind.NativeSig, k => sigs(Memory(), Strings(), Labels()));

        public NativeSigRef Sig(string scope, string name, NativeType ret, params NativeOpDef[] ops)
            => Sigs().Sig(scope, name,ret,ops);

        public NativeSigRef Sig(NativeSigSpec spec)
            => Sigs().Sig(spec);
    }
}