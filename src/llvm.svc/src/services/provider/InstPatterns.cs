//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public Index<LlvmAsmInstPattern> InstPatterns(AsmIdentifiers asmids, Index<LlvmEntity> src)
            => (Index<LlvmAsmInstPattern>)DataSets.GetOrAdd(nameof(LlvmAsmInstPattern), _ => DataCalcs.CalcInstPatterns(asmids, src));

        public Index<LlvmAsmInstPattern> InstPatterns()
            => InstPatterns(AsmIdentifiers(), Entities());        
    }
}