//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public ConstLookup<string,EntityLineage> DefLineage()
            => (ConstLookup<string,EntityLineage>)DataSets.GetOrAdd(nameof(DefLineage), key => DataCalcs.CalcDefLineage(DefRelations()));
    }
}