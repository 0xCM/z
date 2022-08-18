//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Event(Kind)]
    public readonly struct RunningEvent : IInitialEvent<RunningEvent>
    {
        public const string EventName = GlobalEvents.Running;

        public const EventKind Kind = EventKind.Running;

        public static EventLevel Level => FlairKind.Status;

        public FlairKind Flair => FlairKind.Running;

        public EventId EventId {get;}

        [MethodImpl(Inline)]
        public RunningEvent(Type host)
        {
            EventId = EventId.define(EventName, host);
        }

        [MethodImpl(Inline)]
        public string Format()
            => EventId.Format();

        public override string ToString()
            => Format();

    }
}