//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a means by which agents can be queried and directed
    /// </summary>
    public interface IAgentControl : IDisposable
    {
        AgentStats SummaryStats {get;}

        Task Configure(IAgentContext config);
    }

    public interface IAgentControl<S,C> : IAgentControl
        where S : IAgentControl
        where C : IAgentContext
    {
        Task Configure(C context);

        Task IAgentControl.Configure(IAgentContext context)
            => Configure(context);

        event Action<C> Configured;
    }
}