//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public ReadOnlySpan<TextLine> DefLines(string name)
        {
            if(DefLineLookup().Find(name, out var interval))
                return RecordLines(LlvmTargetName.x86, interval);
            return default;
        }
    }
}