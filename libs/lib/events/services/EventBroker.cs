//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    public class EventBroker : IEventBroker
    {
        readonly Dictionary<Type,ISink> Subscriptions;

        readonly Dictionary<ulong, Receiver<IAppEvent>> Receivers;

        public IEventSink Sink {get;}

        object locker;

        readonly bool Owner;

        [MethodImpl(Inline)]
        internal EventBroker(IEventSink sink, bool owner)
        {
            Owner = owner;
            Sink = sink;
            Subscriptions = new Dictionary<Type,ISink>();
            Receivers = new Dictionary<ulong, Receiver<IAppEvent>>();
            locker = new object();
        }

        public void Dispose()
        {
            if(Owner)
                Sink.Dispose();
        }

        public Outcome Subscribe<S,E>(S sink, E model)
            where E : IAppEvent
            where S : ISink
        {
            if(Subscriptions.TryAdd(typeof(E), sink))
                return true;
            else
                return (false, $"Key for {model} was previously added for {sink}");
        }

        [MethodImpl(Inline)]
        static EventRelay<E> relay<E>(Action<E> receiver)
            where E : IAppEvent
                => new EventRelay<E>(receiver);

        [MethodImpl(Inline)]
        public Outcome Subscribe<E>(Action<E> receiver, E model = default)
            where E : IAppEvent
                => Subscribe(relay(receiver), model);

        public void Cancel(ulong session)
        {
            lock(locker)
                Receivers.Remove(session);
        }

        void Emit(IWfEvent e)
            => iter(Receivers.Values, r => r(e));

        void Emit(IAppEvent e)
            => iter(Receivers.Values, r => r(e));

        public void Raise(IWfEvent e)
            => Emit(e);

        public void Raise(IAppEvent e)
            => Emit(e);

        public void Deposit(IWfEvent e)
            => Sink.Deposit(e);

        public void Deposit(IAppEvent e)
            => term.print(e);

        public void Deposit(IAppMsg e)
            => term.print(e);
    }
}