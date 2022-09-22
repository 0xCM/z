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
        /// *.enc.asm -> *.syn.asm
        /// </summary>
        public class EncAsmToSynAsm : FileFlow<EncAsmToSynAsm,LlvmMc>
        {
            public EncAsmToSynAsm()
                : base(llvm_mc, K.EncAsm, K.SynAsm)
            {

            }
        }
    }
}