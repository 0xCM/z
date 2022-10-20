//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class PbCmd : WfAppCmd<PbCmd>
    {
        PolyBits PolyBits => Service(Wf.PolyBits);
    }
}