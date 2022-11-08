//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    public partial class IntelSdmCmd : WfAppCmd<IntelSdmCmd>
    {
        IntelSdm Sdm => Wf.IntelSdm();
    }
}