//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly struct EventHubs
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op]
        public static EventHub hub(int capacity = 128)
            => new EventHub(capacity);

        [MethodImpl(Inline), Op]
        public static EventHubClient client(IEventHub hub, IWfEventSinkDeprecated sink, Action connect, Action exec)
            => new EventHubClient(hub, sink, connect, exec);

        [MethodImpl(Inline)]
        public static HubRelay relay(EventReceiver receiver)
            => new HubRelay(receiver);

        [MethodImpl(Inline)]
        public static HubRelay<E> relay<E>(EventReceiver<E> receiver)
            where E : struct, IWfEvent
                => new HubRelay<E>(receiver);

        [MethodImpl(Inline)]
        public static ref readonly E broadcast<E>(EventHub hub, in E e)
            where E : struct, IWfEvent
        {
            if(hub.Index.TryGetValue(e.GetType(), out var sink))
                sink.Deposit(e);
            return ref e;
        }

        [MethodImpl(Inline)]
        public static bool subscribe<E>(EventHub hub, EventReceiver receiver, E model = default)
            where E : struct, IWfEvent
                => subscribe(hub, new HubRelay(receiver), model);

        [MethodImpl(Inline), Op]
        public static bool subscribe(EventHub hub, EventReceiver receiver, IAppEvent model)
            => hub.Index.TryAdd(model.GetType(), new HubRelay(receiver));

        [MethodImpl(Inline)]
        public static bool subscribe<S,E>(EventHub hub, S sink, E model)
            where E : struct, IWfEvent
            where S : IWfEventSinkDeprecated
                => hub.Index.TryAdd(typeof(E), sink);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static DataHandler<T> handler<T>(DataReceiver<T> receiver)
            => new DataHandler<T>(receiver);
    }
}