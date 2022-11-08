//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public sealed class WfEventQueue : IEventSink, IEventEmitter
    {
        public static WfEventQueue allocate(Type host)
            => new WfEventQueue(host);

        public static WfEventQueue allocate(Type host, Action<IEvent> receiver)
            => new WfEventQueue(host, receiver);

        readonly ConcurrentQueue<IEvent> Storage = new();

        readonly Action<IEvent> Receiver;

        readonly WfEventSignal Signal;

        readonly Type Host;

        internal WfEventQueue(Type host)
        {
            Host = host;
            Receiver = e => {};
            Signal = Events.signal(this, Host);
        }

        internal WfEventQueue(Type host, Action<IEvent> receiver)
        {
            Host = host ?? GetType();
            Receiver = receiver;
            Signal = Events.signal(this, Host);
        }

        public void Deposit(IEvent e)
        {
            if(e != null)
            {
                start(() => Receiver.Invoke(e));
                Storage.Enqueue(e);
            }
            else
                term.error("Null messages don't belong in the queue");

        }

        public void Dispose()
        {
            if(Storage.Count != 0)
                term.warn("Nonempty queue disposed");
        }

        [MethodImpl(Inline)]
        public bool Next(out IEvent e)
            => Storage.TryDequeue(out e);
    }
}