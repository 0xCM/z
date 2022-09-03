//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp("llvm/emit/fields/types")]
        Outcome EmitFieldTypes(CmdArgs args)
        {
            Query.FileEmit("llvm/def/fields/types", DataProvider.DataTypes(DataProvider.DefFields(LlvmTargetName.x86)).View);
            Query.FileEmit("llvm/classes/fields/types", DataProvider.DataTypes(DataProvider.ClassFields()).View);
            return true;
        }
    }
}