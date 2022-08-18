//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = EventHubs;

    public readonly struct EventHub : IEventHub
    {
        internal readonly Dictionary<Type,IWfEventSinkDeprecated> Index;

        [MethodImpl(Inline)]
        internal EventHub(int capacity)
            => Index = new Dictionary<Type,IWfEventSinkDeprecated>(capacity);

        [MethodImpl(Inline)]
        public void Subscribe<E>(E e, EventReceiver<E> receiver)
            where E : struct, IWfEvent
                => api.subscribe(this, api.relay(receiver), e);

        [MethodImpl(Inline)]
        public void Subscribe<E>(E e, EventReceiver receiver)
            where E : struct, IWfEvent
                => api.subscribe(this, receiver, e);

        [MethodImpl(Inline)]
        public void Subscribe(IAppEvent e, EventReceiver receiver)
            => api.subscribe(this, receiver, e);

        [MethodImpl(Inline)]
        public ref readonly E Broadcast<E>(in E e)
            where E : struct, IWfEvent
                => ref api.broadcast(this, e);
    }
}