//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmTableLoader
    {
        public Index<string> LoadConfiguredListNames()
        {
            var src = LlvmPaths.SourceSettings().Path("ListEmissions", FileKind.List);
            var lines = src.ReadLines();
            return lines.Select(x => x.Trim()).Where(x => nonempty(x));
        }
    }
}