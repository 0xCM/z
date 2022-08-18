//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [FileFlowType]
    public abstract class FileFlowType<F,A,K> : DataFlow<F,A,K,K>, IFlowType
        where A : IActor
        where K : unmanaged
        where F : FileFlowType<F,A,K>, new()
    {
        protected FileFlowType(A actor, K src, K dst)
            : base(actor,src,dst)
        {

        }

        IActor IFlowType.Actor
            => Actor;
    }
}