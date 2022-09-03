//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a sink that forwards deposits to a receiver
    /// </summary>
    public readonly struct EventRelay<E> : ISink<E>
        where E : IAppEvent
    {
        readonly Action<E> Receiver;

        [MethodImpl(Inline)]
        public EventRelay(Action<E> receiver)
            => Receiver = receiver;

        [MethodImpl(Inline)]
        public void Deposit(E e)
            => Receiver(e);
    }
}