//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(StructLayout)]
    public record struct CmdExecStatus
    {
        public const string TableId = "cmd.status";

        public int Id;

        public Timestamp StartTime;

        public bool HasExited;

        public Timestamp ExitTime;

        public TimeSpan Duration;

        public int ExitCode;

        public static CmdExecStatus Empty => default;
    }
}