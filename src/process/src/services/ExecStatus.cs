//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(StructLayout)]
    public record struct ExecStatus
    {
        public const string TableId = "cmd.status";

        public ProcessId Id;

        public ExecToken Token;

        public Timestamp StartTime;

        public bool HasExited;

        public Timestamp ExitTime;

        public Duration Duration;

        public int ExitCode;

        public static ExecStatus Empty => default;
    }
}