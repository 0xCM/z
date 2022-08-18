//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public AsmIdentifiers AsmIdentifiers()
            => (AsmIdentifiers)DataSets.GetOrAdd(nameof(AsmIdentifiers), key => DataLoader.LoadAsmIdentifiers());
    }
}