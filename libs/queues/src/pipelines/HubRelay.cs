//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a sink that forwards deposits to a receiver
    /// </summary>
    public readonly struct HubRelay : IWfEventSinkDeprecated
    {
        readonly EventReceiver Receiver;

        [MethodImpl(Inline)]
        public HubRelay(EventReceiver receiver)
            => Receiver = receiver;

        [MethodImpl(Inline)]
        public void Deposit(IWfEvent e)
            => Receiver(e);

        [MethodImpl(Inline)]
        public void Deposit<S>(in S e)
            where S : struct, IWfEvent
                => Receiver(e);
    }
}