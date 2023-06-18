//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record struct ExecutingProcess
    {
        public readonly ProcessId Id;

        public readonly CmdLine CmdLine;   

        public readonly Timestamp Started;

        public ExecutingProcess(CmdLine cmd, ProcessAdapter? process)
        {
            CmdLine = cmd;
            Started = process?.StartTime ?? Timestamp.Zero;
            Id = process?.Id ?? ProcessId.Empty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Id.IsNonEmpty;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Id.IsEmpty;
        }        

        public static ExecutingProcess Empty 
            => new (CmdLine.Empty, null);
    }
}