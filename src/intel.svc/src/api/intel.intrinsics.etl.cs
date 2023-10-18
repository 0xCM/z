//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class IntelCmd
{
    [CmdOp("intel/inx/etl")]
    void RunIntrinsicsEtl()
    {
        Intrinsics.RunEtl();
    }
}
