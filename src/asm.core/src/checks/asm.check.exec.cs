//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class AsmCheckCmd
    {
         PolyBits PolyBits => Wf.PolyBits();

        // [CmdOp("pb/check")]
        // Outcome CheckBits(CmdArgs args)
        // {
        //     PolyBits.Check();
        //     return true;
        // }
        [CmdOp("asm/check/exec")]
        void CheckCodeExec()
        {
            AsmCheckExec.run(Emitter);        
        }
    }
}