//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public Index<LlvmInstDef> InstDefs()
            => InstDefs(AsmIdentifiers(), Entities());

        public Index<LlvmInstDef> InstDefs(AsmIdentifiers lookup, Index<LlvmEntity> entities)
            => (Index<LlvmInstDef>)DataSets.GetOrAdd("InstDefs", key => DataCalcs.CalcInstDefs(lookup,entities));
    }
}