//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class PbCmd
    {
        [CmdOp("pb/bv/emit")]
        Outcome GenBitVectors(CmdArgs args)
        {
            var result = Outcome.Success;
            var filter = "llvm.lists";
            //var sources = AppDb.LlvmSources().Scoped("tables");
            //var targets = AppDb.LlvmTargets().Targets("emitted");
            //var dst = targets.OutDir("bitvectors");
            //dst.Clear();
            //PolyBits.BvEmit(sources, filter, dst);
            return result;
        }

        [CmdOp("pb/emit")]
        Outcome Emit(CmdArgs args)
        {
            PolyBits.EmitPatterns();
            return true;
        }
    }
}