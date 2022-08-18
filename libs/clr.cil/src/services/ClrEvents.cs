//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Diagnostics.Tracing;

    using static core;

    using Level = System.Diagnostics.Tracing.EventLevel;

    public partial class RuntimeEvents
    {
    }

    [ApiHost]
    public partial class RuntimeObservers
    {

    }

    public class ClrEventListener : EventListener, IDisposable
    {
        static void render(EventWrittenEventArgs src, ITextBuffer dst)
        {
            dst.AppendLine(src.EventName);
            dst.AppendLine(RpOps.PageBreak80);
            var count = src.Payload.Count;
            for(int i = 0; i<count; i++)
            {
                var name = string.Format("{0,-32}:",src.PayloadNames[i]);
                var payload = string.Format("{0}",src.Payload[i]);
                var message = string.Concat(name,payload);
                dst.AppendLine(message);
            }
        }

        async Task EmitAsync(EventWrittenEventArgs src)
        {
            var buffer = text.buffer();
            render(src,buffer);
            await Log.WriteLineAsync(buffer.Emit());
        }

        public static ClrEventListener create(FS.FilePath log)
            => new ClrEventListener(log);

        HashSet<string> EventNames;

        Action<EventWrittenEventArgs> Receiver;

        StreamWriter Log;

        void Emit(EventWrittenEventArgs e)
            => EmitAsync(e).Wait();

        public ClrEventListener(FS.FilePath dst)
            : this("MethodLoad_V1","MethodLoadVerbose_V1","MethodJitInliningSucceeded", "MethodJitInliningFailed")
        {
            Log = dst.AsciWriter();
        }

        ClrEventListener(params string[] events)
        {
            Receiver = Emit;
            EventNames = hashset(events);
        }

        protected override void OnEventSourceCreated(EventSource src)
        {
            EventKeywords keywords = (EventKeywords)(0x1010);
            EnableEvents(src, Level.Verbose, keywords);
        }

        protected override void OnEventWritten(EventWrittenEventArgs data)
        {
            if (!EventNames.Contains(data.EventName))
                return;

            Receiver(data);
        }

        public override void Dispose()
        {
            base.Dispose();
            Log?.Flush();
            Log?.Dispose();
        }
    }
}