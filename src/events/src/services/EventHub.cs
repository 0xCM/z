//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using api = EventHubs;

public readonly struct EventHub : IEventHub
{
    internal readonly Dictionary<Type,IEventSink> Index;

    [MethodImpl(Inline)]
    internal EventHub(int capacity)
        => Index = new Dictionary<Type,IEventSink>(capacity);

    [MethodImpl(Inline)]
    public void Subscribe<E>(E model, EventHandler receiver)
        where E : IEvent<E>, new()
            => api.subscribe(this, receiver, model);

    [MethodImpl(Inline)]
    public ref readonly E Broadcast<E>(in E e)
        where E : IEvent<E>, new()
            => ref api.broadcast(this, e);        
}
