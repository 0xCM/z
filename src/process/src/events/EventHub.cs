//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = EventHubs;

    public readonly struct EventHub : IEventHub
    {
        internal readonly Dictionary<Type,IEventSink> Index;

        [MethodImpl(Inline)]
        internal EventHub(int capacity)
            => Index = new Dictionary<Type,IEventSink>(capacity);

        [MethodImpl(Inline)]
        public void Subscribe<E>(E e, EventReceiver receiver)
            where E : struct, IEvent
                => api.subscribe(this, receiver, e);

        [MethodImpl(Inline)]
        public void Subscribe(IAppEvent e, EventReceiver receiver)
            => api.subscribe(this, receiver, e);

        [MethodImpl(Inline)]
        public ref readonly E Broadcast<E>(in E e)
            where E : struct, IEvent
                => ref api.broadcast(this, e);        
    }
}