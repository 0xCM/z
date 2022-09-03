//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmDataProvider
    {
        public ReadOnlySpan<TextLine> ClassLines(string name)
        {
            var lines = list<TextLine>();
            if(ClassLineLookup().Find(name, out var interval))
                return RecordLines(LlvmTargetName.x86, interval);
            return lines.ViewDeposited();
        }
    }
}