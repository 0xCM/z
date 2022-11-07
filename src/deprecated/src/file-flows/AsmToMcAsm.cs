//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = FileKind;

    using static Tools;

    partial class FileFlows
    {
        /// <summary>
        /// *.asm -> *.mc.asm
        /// </summary>
        public class AsmToMcAsm : FileFlow<AsmToMcAsm,LlvmMc>
        {
            public AsmToMcAsm()
                : base(llvm_mc, K.Asm, K.McAsm)
            {

            }
        }
    }
}