//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    readonly struct CheckEventTarget : IEventTarget
    {
        public static IEventTarget create(IWfChannel channel)
            => new CheckEventTarget(channel);
            
        readonly Action<IEvent> Receiver;

        public CheckEventTarget(IWfChannel channel)
        {
            Receiver = (e) => channel.Raise(e);
        }

        public void Deposit(IEvent src)
            => Receiver(src);
    }
}