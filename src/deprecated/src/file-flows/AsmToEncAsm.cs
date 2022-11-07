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
        /// *.asm -> *.enc.asm
        /// </summary>
        public class AsmToEncAsm : FileFlow<AsmToEncAsm,LlvmMc>
        {
            public AsmToEncAsm()
                : base(llvm_mc, K.Asm, K.EncAsm)
            {

            }
        }
    }
}