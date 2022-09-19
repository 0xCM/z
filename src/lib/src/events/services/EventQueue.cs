//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public sealed class EventQueue : IEventSink, IEventEmitter
    {
        public static EventQueue allocate(Type host)
            => new EventQueue(host);

        public static EventQueue allocate(Type host, Action<IWfEvent> receiver)
            => new EventQueue(host, receiver);

        readonly ConcurrentQueue<IWfEvent> Storage = new();

        readonly Action<IWfEvent> Receiver;

        readonly EventSignal Signal;

        readonly Type Host;

        internal EventQueue(Type host)
        {
            Host = host;
            Receiver = e => {};
            Signal = Events.signal(this, Host);
        }

        internal EventQueue(Type host, Action<IWfEvent> receiver)
        {
            Host = host ?? GetType();
            Receiver = receiver;
            Signal = Events.signal(this, Host);
        }

        public void Deposit(IWfEvent e)
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
        public bool Next(out IWfEvent e)
            => Storage.TryDequeue(out e);
    }
}