//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct FileSplitInfo
    {
        public readonly FileSplitSpec Spec;

        public readonly Files TargetFiles;

        public readonly Count TotalLineCount;

        [MethodImpl(Inline)]
        public FileSplitInfo(FileSplitSpec spec, Files dst, Count total)
        {
            Spec = spec;
            TargetFiles = dst;
            TotalLineCount = total;
        }
    }
}