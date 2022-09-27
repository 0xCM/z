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

        public void Deposit(IWfEvent e)
            => Sink.Deposit(e);

        public void Deposit<S>(in S e)
            where S : struct, IWfEvent
                => Sink.Deposit(e);

        [MethodImpl(Inline)]
        public void Connect()
            => Connector();

        [MethodImpl(Inline)]
        public void Exec()
            => Executor();
    }
}