//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    class FsmCmd : AppCmdService<FsmCmd>
    {
        [CmdOp("fsm/checks")]
        void CheckFsm()
        {
            RunFsm.Run(Wf);
        }
    }
}