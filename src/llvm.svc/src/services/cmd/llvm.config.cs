//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static sys;

    partial class LlvmCmd
    {
        [CmdOp("llvm/config")]
        void CollectConfig()
        {
           var config = Config.CollectSettings();
           var items = config.Items;
           var dst = text.emitter();
           iter(items, item => dst.AppendLine($"{item.Key}={item.Value}"));
           FileEmit(dst.Emit(), items.Count, AppDb.DbTargets(llvm).Path(llvm, FileKind.Cfg));               
        }
    }
}