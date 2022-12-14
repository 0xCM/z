//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmTableLoader
    {
        public LlvmRegIdentifiers LoadRegIdentifiers()
        {
            const string TableId = "llvm.asm.RegId";
            var items = LoadList(LlvmPaths.DbTable(TableId));
            var dst = list<LlvmRegIdentifier>();
            foreach(var id in items)
                dst.Add(new LlvmRegIdentifier((ushort)id.Key, id.Value.Trim()));
            return dst.Array().Sort();
        }
    }
}