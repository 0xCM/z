//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed record class ExecutingProcess
    {
        static CmdExecStatus status(ExecutingProcess src)
        {
            var dst = CmdExecStatus.Empty;
            dst.Id = src.Id;
            dst.StartTime = src.Started;
            dst.HasExited = src.Finished;
            if(src.Finished)
            {
                dst.ExitTime = src.Adapted.ExitTime;
                dst.Duration = dst.ExitTime - dst.StartTime;
                dst.ExitCode = src.Adapted.ExitCode;
            }
            return dst;
        }

        public ExecutingProcess(CmdLine cmd, ProcessAdapter? process)
        {
            CmdLine = cmd;
            Started = process?.StartTime ?? Timestamp.Zero;
            Id = process?.Id ?? ProcessId.Empty;
            Adapted = process!;
        }

        public readonly ProcessId Id;

        public readonly CmdLine CmdLine;   

        public readonly Timestamp Started;
        
        public readonly ProcessAdapter Adapted;

        public void Close()
            => Adapted.Close();
            
        public bool Finished
        {
            [MethodImpl(Inline)]
            get => Adapted.HasExited;
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

        public CmdExecStatus Status()
            => status(this);

        public static ExecutingProcess Empty 
            => new (CmdLine.Empty, null);
    }
}