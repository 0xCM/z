//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public Index<X86InstDef> Instructions(Index<LlvmEntity> src)
            => (Index<X86InstDef>)DataSets.GetOrAdd("Instructions", _ => src.Where(e => e.IsInstruction()).Select(e => e.ToInstruction()));

        public Index<X86InstDef> Instructions()
            => Instructions(Entities());
    }
}