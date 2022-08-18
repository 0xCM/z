//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public Index<RecordField> DefFields(LlvmTargetName target)
            => Fields(LlvmDatasets.dataset(target).DefFields);
    }
}