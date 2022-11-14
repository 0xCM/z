//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct EventTarget : IEventTarget
    {
        readonly Action<IEvent> Logger;

        [MethodImpl(Inline)]
        public EventTarget(Action<IEvent> logger)
        {
            Logger = logger;
        }

        [MethodImpl(Inline)]
        public void Deposit(IEvent src)
            => Logger(src);
    }
}