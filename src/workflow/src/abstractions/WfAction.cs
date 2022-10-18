//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract record class WfAction<A> : IWfAction<A>
        where A : WfAction<A>, new()
    {
        protected WfAction()
        {

        }

        public static A Empty => new();
    }
}