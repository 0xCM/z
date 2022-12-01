//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    partial class IntelSdm
    {
        public ReadOnlySpan<DocSplitSpec> LoadSplitDefs(FilePath src)
        {
            var outcome = DocServices.load(src, out var specs);
            if(outcome.Fail)
                Channel.Error(outcome.Message);
            return specs;
        }
    }
}