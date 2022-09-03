//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        // public Index<TextLine> SelectRecordLines(string id)
        // {
        //     return (Index<TextLine>)DataSets.GetOrAdd(id + "lines", _ => Load());
        //     Index<TextLine> Load()
        //     {
        //         using var reader = LlvmPaths.DevSource("records", id).Utf8LineReader();
        //         return reader.ReadAll().ToArray();
        //     }
        // }
    }
}