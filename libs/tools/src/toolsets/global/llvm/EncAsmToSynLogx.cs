//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = FileKind;

    partial class Tools
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