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

        // public CompositeDispenser Composite()
        //     => (CompositeDispenser)Data.GetOrAdd(AllocationKind.Composite, k => Dispense.composite(Memory(), Strings(), Labels(), Symbols(), Source()));

        // public NativeSigDispenser Sigs()
        //     => (NativeSigDispenser)Data.GetOrAdd(AllocationKind.NativeSig, k => Dispense.sigs(Memory(), Strings(), Labels()));

        // public NativeSigRef Sig(string scope, string name, NativeType ret, params NativeOpDef[] ops)
        //     => Sigs().Sig(scope, name,ret,ops);

        // public NativeSigRef Sig(NativeSigSpec spec)
        //     => Sigs().Sig(spec);
    }
}