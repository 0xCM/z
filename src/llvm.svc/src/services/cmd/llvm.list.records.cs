//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp("llvm/list/records")]
        void ListRecordFiles(CmdArgs args)
        {
            if(args.Count != 0)
            {
                var project = arg(args,0);
                Query.Emit(LlvmPaths.RecordFiles(project), $"{project}.records.files");
            }
            else
                Query.Emit(LlvmPaths.RecordFiles(), "records.files");
        }
    }
}