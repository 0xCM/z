//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    public class EmissionSink : IEmissionSink<EmissionSink>
    {
        readonly ConcurrentDictionary<EventId,IWfEvent> Storage;

        object Locker;

        internal EmissionSink(ConcurrentDictionary<EventId,IWfEvent> storage)
        {
            Storage = storage;
            Locker = new();
        }

        internal EmissionSink()
            : this(new())
        {
        }

        public void Deposit(IWfEvent src)
            => Storage.TryAdd(src.EventId, src);

        public ReadOnlySpan<IWfEvent> Clear()
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