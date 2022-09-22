//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public LlvmRegIdentifiers RegIdentifiers()
            => (LlvmRegIdentifiers)DataSets.GetOrAdd(nameof(RegIdentifiers), _ => DataLoader.LoadRegIdentifiers());
    }
}