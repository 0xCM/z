//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp("llvm/emit/x86int")]
        void LoadIntrinsics()
        {
            const string ItemFormat = "{0} = {1},";
            var entities = DataProvider.Entities();
            var count = entities.Length;
            var counter = 0u;
            var dst = text.emitter();
            var offset = 4u;
            dst.AppendLine("namespace z0.llvm");
            dst.AppendLine("{");
            dst.IndentLineFormat(offset, "public enum {0} : {1}", "LlvmX86Intrinsic", "ushort");
            dst.IndentLine(offset, "{");
            offset += 4;
            dst.IndentLineFormat(offset, ItemFormat, "None", counter++);
            for(var i=0; i<count; i++)
            {
                ref readonly var entity = ref entities[i];
                if(entity.IsIntrinsic())
                {
                    var intrinsic = entity.ToIntrinsic();
                    if(intrinsic.TargetPrefix == "x86")
                        dst.IndentLineFormat(offset, ItemFormat, intrinsic.EntityName, counter++);
                }
            }
            offset -= 4;
            dst.IndentLine(offset, "}");
            offset -= 4;
            dst.AppendLine("}");

            Query.FileEmit(dst.Emit(), "llvm.x86.intrinsics", FS.Cs);
        }
    }
}