//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a sink that forwards deposits to a receiver
    /// </summary>
    public readonly struct HubRelay<E> : IEventSink<E>
        where E : IEvent<E>, new()
    {
        readonly EventHandler<E> Receiver;

        [MethodImpl(Inline)]
        internal HubRelay(EventHandler<E> receiver)
            => Receiver = receiver;

        [MethodImpl(Inline)]
        public void Deposit(E e)
            => Receiver(e);

        public void Deposit(IEvent e)
            => Receiver((E)e);
    }
}