//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public delegate void OnAgentTransition(AgentTransition transition);

    public interface IAgentEventSink : IDisposable
    {
        void AgentTransitioned(AgentTransition data);

        void Receive(object data);
    }

    public interface IAgentEventSink<S> : IAgentEventSink
    {
        void Receive(S data);
    }
}