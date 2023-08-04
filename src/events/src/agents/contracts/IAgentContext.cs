//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IAgentContext : IDisposable
    {
        IEnumerable<IAgentMachine> Members {get;}

        IAgentEventSink Sink {get;}

        void Register(IAgentMachine agent);
    }
}