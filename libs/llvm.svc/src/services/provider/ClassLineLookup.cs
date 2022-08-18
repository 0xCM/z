//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public IdentityMap<uint> ClassLineLookup()
            => (IdentityMap<uint>)DataSets.GetOrAdd(nameof(ClassLineLookup), key => DataCalcs.CalcIdentityMap(X86ClassMap()));
    }
}