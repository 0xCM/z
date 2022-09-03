//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public RegIdentifiers RegIdentifiers()
            => (RegIdentifiers)DataSets.GetOrAdd(nameof(RegIdentifiers), _ => DataLoader.LoadRegIdentifiers());
    }
}