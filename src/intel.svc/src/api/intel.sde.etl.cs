//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using System.Text;

partial class IntelCmd
{
    [CmdOp("intel/sde/etl")]
    void RunSdeEtl()
    {
        Sde.RunEtl();
    }
}
