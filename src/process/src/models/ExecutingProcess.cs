//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed record class ExecutingProcess
    {
        public ExecutingProcess(CmdArgs args, CmdLine cmd, Timestamp ts, ProcessId id)
        {
            Args = args;
            CmdLine = cmd;
            Started = ts;
            Id = id;
        }

        public readonly CmdArgs Args;

        public readonly CmdLine CmdLine;   

        public readonly Timestamp Started;
        
        public readonly ProcessId Id;

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

        public static ExecutingProcess Empty => new (CmdArgs.Empty, CmdLine.Empty, Timestamp.Zero, ProcessId.Empty);
    }
}