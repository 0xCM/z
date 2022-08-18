//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public Index<LineRelations> DefRelations()
            => (Index<LineRelations>)DataSets.GetOrAdd("DefRelations", key => DataLoader.LoadDefRelations());
    }
}