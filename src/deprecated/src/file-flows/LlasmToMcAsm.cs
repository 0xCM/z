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
        /// *ll.asm -> *.mc.asm
        /// </summary>
        public class LlasmToMcAsm : FileFlow<LlasmToMcAsm,LlvmMc>
        {
            public LlasmToMcAsm()
                : base(llvm_mc, K.Asm, K.McAsm)
            {

            }
        }
    }
}