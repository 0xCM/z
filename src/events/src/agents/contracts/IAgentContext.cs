//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IAgentContext : IDisposable
    {
        IEnumerable<IAgent> Members {get;}

        IAgentEventSink EventLog {get;}

        void Register(IAgent agent);
    }
}