//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed record class ExecutingProcess
    {
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
            => CmdRunner.status(this);

        public static ExecutingProcess Empty 
            => new (CmdLine.Empty, null);
    }
}