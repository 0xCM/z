//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public LlvmList List(string id)
            => (LlvmList)DataSets.GetOrAdd("llvm.lists." + id, _ => DataLoader.LoadList(id));
    }
}