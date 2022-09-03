//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public Index<InstEntity> Instructions(Index<LlvmEntity> src)
            => (Index<InstEntity>)DataSets.GetOrAdd("Instructions", _ => src.Where(e => e.IsInstruction()).Select(e => e.ToInstruction()));

        public Index<InstEntity> Instructions()
            => Instructions(Entities());
    }
}