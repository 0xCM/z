//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a shared context for a set of agents
    /// </summary>
    public sealed class AgentContext : IAgentContext
    {
        public IAgentEventSink Sink {get;}

        ConcurrentBag<IAgentMachine> Agents {get;}
            = new();

        [MethodImpl(Inline)]
        public AgentContext(IAgentEventSink sink)
        {
            Sink = sink;
        }

        public void Register(IAgentMachine agent)
            => Agents.Add(agent);

        public void Dispose()
        {
            Sink.Dispose();
        }

        public IEnumerable<IAgentMachine> Members
            => Agents;
    }
}