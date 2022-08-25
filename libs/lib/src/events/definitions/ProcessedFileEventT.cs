//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [Event(Kind)]
    public readonly struct ProcessedFileEvent<T> : ITerminalEvent<ProcessedFileEvent<T>>
    {
        public const EventKind Kind = EventKind.ProcessedFile;

        public const string EventName = GlobalEvents.ProcessedFile;

        public EventId EventId {get;}

        public FilePath SourcePath {get;}

        public T Data {get;}

        public FlairKind Flair => FlairKind.Processed;

        [MethodImpl(Inline)]
        public ProcessedFileEvent(WfStepId step, FilePath src, T data, PartToken ct)
        {
            EventId = (Kind, step, ct);
            SourcePath = src;
            Data = data;
        }

        [MethodImpl(Inline)]
        public string Format()
            => RpOps.format(RpOps.PSx3, EventId, Data, SourcePath.ToUri());
    }
}