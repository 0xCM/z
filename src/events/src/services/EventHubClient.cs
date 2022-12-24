//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class EventHubClient : IEventHubClient
    {
        public IEventHub Hub {get;}

        readonly IEventSink Sink;

        readonly Action Connector;

        readonly Action Executor;

        [MethodImpl(Inline)]
        public EventHubClient(IEventHub hub, IEventSink sink, Action connect, Action exec)
        {
            Hub = hub;
            Sink = sink;
            Connector = connect;
            Executor = exec;
            Connect();
        }

        public void Deposit(IEvent e)
            => Sink.Deposit(e);

        [MethodImpl(Inline)]
        public void Connect()
            => Connector();

        [MethodImpl(Inline)]
        public void Exec()
            => Executor();
    }
}