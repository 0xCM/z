//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

public sealed class EventQueue : IEventSink, IProducer<IEvent>
{
    public static EventQueue allocate(Type host, Action<IEvent> receiver)
        => new (host, receiver);

    readonly ConcurrentQueue<IEvent> Storage = new();

    readonly Action<IEvent> Receiver;

    EventQueue(Type host, Action<IEvent> receiver)
    {
        Receiver = receiver;
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
