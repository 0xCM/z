//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedOps
    {
        public static IMachine machine(XedRuntime xed)
            => new MachineState(xed);
    }
}