//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [SymSource(events)]
    public enum FlairKind : byte
    {
        None = LogLevel.None,

        Babble = MsgFlair.Babble,

        Status = MsgFlair.Status,

        Trace = MsgFlair.Trace,

        Warning = MsgFlair.Warning,

        Error = MsgFlair.Error,

        Creating = MsgFlair.Babble,

        Created = MsgFlair.Babble,

        Disposed = MsgFlair.Babble,

        Running = ConsoleColor.Cyan,

        Ran = ConsoleColor.Magenta,

        Processed = ConsoleColor.Magenta,

        Data = ConsoleColor.DarkGray,
        
        StatusData = ConsoleColor.Cyan,
    }
}