//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [SymSource(events)]
    public enum EventKind : byte
    {
        None = 0,

        Babble = MsgLevel.Babble,

        Status = MsgLevel.Status,

        Warning = MsgLevel.Warning,

        Error = MsgLevel.Error,

        Running,

        Ran,

        Emitting,

        Emitted,

        EmittingTable,

        EmittedTable,

        EmittingFile,

        EmittedFile,

        Creating,

        Created,

        Disposed,

        RunningCmd,

        CmdRan,

        Processing,

        Processed,

        ProcessingFile,

        ProcessedFile,

        Data,

        Row,

        FileChange,
    }
}