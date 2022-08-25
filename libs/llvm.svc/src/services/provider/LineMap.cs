//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public LineMap<string> LineMap(FilePath src)
            => (LineMap<string>)DataSets.GetOrAdd(src.Format(), _ => DataLoader.LoadLineMap(src));
    }
}