//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class WfProcess<P> : Stateless<P>
        where P : WfProcess<P>,new()
    {
        public static P init(IWfChannel channel, CmdArgs args, FilePath dst)
        {
            var process = new P();
            process.Channel = channel;
            process.Exe = FS.path(args[0]);
            process.Args = args;
            process.Dst = dst;
            return process;
        }

        protected IWfChannel Channel {get;private set;}

        protected FilePath Exe {get;private set;}

        protected CmdArgs Args {get;private set;}

        protected FilePath Dst {get;private set;}

        protected virtual string RunningMsg => $"Executing {Exe}:{Args}";

        protected virtual string RanMsg => $"Executed {Exe}:{Args}";

        public event Action<ExecToken> ProcessRunning;

        public event Action<ExecToken> ProcessRan;

        ExecFlow<string> Running()
        {
            var flow = Channel.Running(RunningMsg);
            if(ProcessRunning != null)
                sys.start(() => ProcessRunning(flow.Token));
            return flow;
        }

        ExecToken Ran(ExecFlow<string> flow)
        {
            var token = Channel.Ran(flow, RanMsg);
            if(ProcessRan != null)
                sys.start(() => ProcessRan(token));
            return token;
        }

        public Task<ExecToken> Start()
        {
            var flow = Running();
            var task = ProcExec.redirect(Channel, Args, Dst);            
            return task.ContinueWith(t => Ran(flow));  
        }
    }
}