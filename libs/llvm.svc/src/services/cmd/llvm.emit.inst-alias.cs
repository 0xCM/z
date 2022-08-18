//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp("llvm/emit/inst-alias")]
        void RunInstAliasQuery(CmdArgs args)
            => TableEmit(DataProvider.InstAliases(), Paths.DbTable<LlvmInstAlias>());
    }
}