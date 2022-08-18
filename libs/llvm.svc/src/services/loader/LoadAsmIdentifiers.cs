//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmTableLoader
    {
        public AsmIdentifiers LoadAsmIdentifiers()
        {
            const string TableId = "llvm.asm.AsmId";
            var items = LoadList(LlvmPaths.DbTable(TableId));
            var dst = list<AsmIdentifier>();
            foreach(var id in items)
                dst.Add(new AsmIdentifier((ushort)id.Key, id.Value.Trim()));
            return dst.Array().Sort();
        }
    }
}