//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public LineMap<string> X86ClassMap()
            => LineMap(LlvmPaths.LineMap(LlvmDatasets.dataset(LlvmTargetName.x86).Classes));
    }
}