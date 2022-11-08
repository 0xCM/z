//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    public class EmissionSink : IEventSink
    {
        readonly ConcurrentDictionary<EventId,IEvent> Storage;

        object Locker;

        public EmissionSink(ConcurrentDictionary<EventId,IEvent> storage)
        {
            Storage = storage;
            Locker = new();
        }

        public EmissionSink()
            : this(new())
        {
        }

        public void Deposit(IEvent src)
            => Storage.TryAdd(src.EventId, src);

        public ReadOnlySpan<IEvent> Clear()
        {
            lock(Locker)
            {
                var events = Storage.Values.ToArray();
                Storage.Clear();
                return events;
            }
        }

        public void Dispose()
        {
            if(Storage.Count != 0)
                term.warn("Sink disposed while events remain enqueued");
        }
    }
}