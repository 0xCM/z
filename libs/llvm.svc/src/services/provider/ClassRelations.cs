//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public Index<LineRelations> ClassRelations()
            => (Index<LineRelations>)DataSets.GetOrAdd("ClassRelations", key => DataLoader.LoadClassRelations());
    }
}