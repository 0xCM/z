//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a sink that forwards deposits to a receiver
    /// </summary>
    public readonly struct HubRelay : IEventSink
    {
        readonly EventHandler Receiver;

        [MethodImpl(Inline)]
        public HubRelay(EventHandler receiver)
            => Receiver = receiver;

        [MethodImpl(Inline)]
        public void Deposit(IEvent e)
            => Receiver(e);

        public void Dispose()
        {
            
        }
    }
}