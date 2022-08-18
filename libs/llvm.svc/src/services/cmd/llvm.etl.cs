//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp("llvm/etl")]
        Outcome LlvmEtl(CmdArgs args)
        {
            Importer.Run();
            return true;
        }
    }
}