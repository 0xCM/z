//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [SymSource(events)]
    public enum MsgFlair : byte
    {
        None = LogLevel.None,

        Babble = ConsoleColor.DarkGray,

        Status = ConsoleColor.Green,

        Trace = ConsoleColor.DarkGray,

        Warning = ConsoleColor.Yellow,

        Error = ConsoleColor.Red,
    }
}