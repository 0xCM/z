//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

public class EventBroker : IEventBroker
{
    readonly Dictionary<Type,ISink> Subscriptions;

    readonly Dictionary<ulong, Receiver<IEvent>> Receivers;

    public IEventSink Sink {get;}

    object locker;

    readonly bool Owner;

    [MethodImpl(Inline)]
    public EventBroker(IEventSink sink, bool owner)
    {
        Owner = owner;
        Sink = sink;
        Subscriptions = new Dictionary<Type,ISink>();
        Receivers = new Dictionary<ulong, Receiver<IEvent>>();
        locker = new object();
    }

    public void Dispose()
    {
        if(Owner)
            Sink.Dispose();
    }

    public Outcome Subscribe<S,E>(S sink, E model)
        where E : IEvent
        where S : ISink
    {
        if(Subscriptions.TryAdd(typeof(E), sink))
            return true;
        else
            return (false, $"Key for {model} was previously added for {sink}");
    }

    [MethodImpl(Inline)]
    static EventRelay<E> relay<E>(Action<E> receiver)
        where E : IEvent
            => new (receiver);

    [MethodImpl(Inline)]
    public Outcome Subscribe<E>(Action<E> receiver, E model = default)
        where E : IEvent
            => Subscribe(relay(receiver), model);

    public void Cancel(ulong session)
    {
        lock(locker)
            Receivers.Remove(session);
    }

    void Emit(IEvent e)
        => iter(Receivers.Values, r => r(e));

    public void Deposit(IEvent e)
        => Emit(e);

    public void Deposit(IAppMsg e)
        => term.print(e);
}
