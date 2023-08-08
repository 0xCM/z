//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Agent]
    public abstract class Agent<A> : IAgent<A>
        where A : Agent<A>, new()
    {
        protected IWfRuntime Wf;

        protected IWfChannel Channel;

        public static A create(IWfRuntime wf)
        {
            var agent = new A(){
                Wf = wf
            };
            agent.Init();
            return agent;
        }

        protected virtual void Init() {}

        public abstract Task Start();

        public abstract Task Stop();
    }
}