//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Diagnostics.Tracing;

    using Level = System.Diagnostics.Tracing.EventLevel;

    public abstract class TraceEventObserver<E> : EventListener
        where E : struct
    {
        readonly string EventName;

        readonly object locker = new();

        StreamWriter LogStream;

        StreamWriter Log
        {
            get
            {
                lock(locker)
                {
                    if(LogStream == null)
                    {
                        LogStream = LogPath.AsciWriter();
                        LogStream.WriteLine(Formatter.FormatHeader());

                    }
                }
                return LogStream;
            }
        }

        FilePath LogPath;

        readonly ICsvFormatter<E> Formatter;

        readonly uint EventKeyword;

        ulong Counter;

        public override void Dispose()
        {
            base.Dispose();
            if(LogStream != null)
            {
                LogStream.Flush();
                LogStream.Dispose();
            }
        }

        protected TraceEventObserver(uint keyword, string @event, FilePath log)
        {
            LogPath = log;
            EventKeyword = keyword;
            EventName = @event;
            Formatter = Tables.formatter<E>();
        }

        protected override void OnEventSourceCreated(EventSource src)
        {
            EnableEvents(src, Level.LogAlways, (EventKeywords)EventKeyword);
        }

        protected override void OnEventWritten(EventWrittenEventArgs args)
        {
            if (args.EventName != EventName)
                return;

            Log.WriteLine(Formatter.Format(Decode(args)));
            Counter++;
        }

        protected abstract E Decode(EventWrittenEventArgs src);
    }
}