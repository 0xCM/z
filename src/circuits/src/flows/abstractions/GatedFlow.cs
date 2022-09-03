//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class GatedFlow<F,T>
        where F : GatedFlow<F,T>, new()
        where T : unmanaged
    {
        public abstract FlowGateKind Kind {get;}
    }
}