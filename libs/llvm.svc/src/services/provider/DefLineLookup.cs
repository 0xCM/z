//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public IdentityMap<uint> DefLineLookup()
            => (IdentityMap<uint>)DataSets.GetOrAdd(nameof(DefLineLookup), _ => DataCalcs.CalcIdentityMap(X86DefMap()));
    }
}