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
        /// *.enc.asm -> *.syn.asm.log
        /// </summary>
        public class EncAsmToSynLog : FileFlow<EncAsmToSynLog, LlvmMc>
        {
            public EncAsmToSynLog()
                : base(llvm_mc, K.EncAsm, K.SynAsmLog)
            {

            }
        }
    }
}