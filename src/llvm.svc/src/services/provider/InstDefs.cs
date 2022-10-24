//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public Index<Z0.LlvmInstDef> InstDefs()
            => InstDefs(AsmIdentifiers(), Entities());

        public Index<Z0.LlvmInstDef> InstDefs(AsmIdentifiers lookup, Index<LlvmEntity> entities)
            => (Index<Z0.LlvmInstDef>)DataSets.GetOrAdd("InstDefs", key => DataCalcs.CalcInstDefs(lookup, entities));
    }
}