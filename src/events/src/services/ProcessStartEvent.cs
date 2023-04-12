//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableName)]
    public record class ProcessStartEvent : IInitialEvent<ProcessStartEvent>
    {
        const string TableName = "process.start";

        EventId IEvent.EventId 
            => EventId;
        
        public EventId EventId;

        public ProcessId ParentId;

        public ProcessId ProcessId;

        public Timestamp StartTime;

        public @string ProcessName;

        public @string CommandLine;

        public ProcessStartEvent()
        {

        }

        public ProcessStartEvent(ProcessId parent, ProcessId id, Timestamp start, @string name, @string cmdline)
        {
            EventId = Z0.EventId.define(TableName,start);
            ParentId = parent;
            ProcessId = id;
            StartTime = start;
            ProcessName = name;
            CommandLine = cmdline;
        }

        public string Format()
            => Json.serialize(this);

        public override string ToString()
            => Format();
    }
}