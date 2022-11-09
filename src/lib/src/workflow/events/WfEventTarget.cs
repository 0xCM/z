//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct WfEventTarget : IEventTarget
    {
        readonly Action<IEvent> Logger;

        [MethodImpl(Inline)]
        public WfEventTarget(Action<IEvent> logger)
        {
            Logger = logger;
        }

        [MethodImpl(Inline)]
        public void Deposit(IEvent src)
            => Logger(src);
    }
}