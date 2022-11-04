//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class AgentControl<A,C> : AppService<A>, IAgentControl<A,C>
        where A : AgentControl<A,C>, new()
        where C : IAgentContext
    {
        protected AgentControl()
        {

        }

        public static A create(C context)
        {
            var dst = new A();
            dst.Context = context;
            dst.Configure(context);
            return dst;
        }

        protected C Context;

        public AgentStats SummaryStats {get; protected set;}

        public event Action<C> Configured;

        protected abstract Task Configure(C context);

        async Task IAgentControl<A,C>.Configure(C contxt)
        {
            await Configure(contxt);
            OnConfigured(contxt);
        }

        void OnConfigured(C context)
            => Configured?.BeginInvoke(context, new AsyncCallback(x => {}), this);

        public async Task Configure(dynamic config)
        {
            await Configure((C)config);
        }

        protected virtual void OnConfigure(dynamic config) {}

    }
}