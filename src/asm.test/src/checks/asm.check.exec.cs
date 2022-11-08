//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class AsmCheckCmd
    {
        [CmdOp("asm/check/exec")]
        void CheckCodeExec()
        {
            AsmCheckExec.run(Emitter);        
        }
    }
}