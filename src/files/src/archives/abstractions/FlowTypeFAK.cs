//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [FileFlowType]
    public abstract class FlowType<F,A,K> : DataFlow<F,A,K,K>, IFlowType
        where A : IActor
        where K : unmanaged
        where F : FlowType<F,A,K>, new()
    {
        protected FlowType(A actor, K src, K dst)
            : base(actor,src,dst)
        {

        }

        IActor IFlowType.Actor
            => Actor;
    }
}