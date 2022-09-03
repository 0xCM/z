//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmCmd
    {
        const string DagOpQuery = "llvm/defs/dagops";

        [CmdOp(DagOpQuery)]
        Outcome QueryDagOps(CmdArgs args)
        {
            var src = DataProvider.Entities(e => e.IsDAGOperand()).Select(e => e.ToDAGOperand());
            var count = src.Count;
            var dst = list<string>();
            for(var i=0; i<count; i++)
            {
                ref readonly var entity = ref src[i];
                dst.Add(string.Format("{0,-24} | {1,-16} | {2,-24} | {3}", entity.EntityName, entity.Type, entity.OperandType, entity.MIOperandInfo));
            }

            Query.FileEmit(DagOpQuery, @readonly(dst.Array()));

            return true;
        }
    }
}
