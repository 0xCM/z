//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using System.Text;

public partial class IntelCmd : WfAppCmd<IntelCmd>
{
    IntelIntrinsics Intrinsics => Wf.IntelIntrinsics();

    IntelSdm Sdm => Wf.IntelSdm();

    SdeSvc Sde => Wf.SdeSvc();


    [CmdOp("intel/etl")]
    void ImportIntrinsics()
    {
        Sde.RunEtl();
    }

}
