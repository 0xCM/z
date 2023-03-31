//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class ToolProcess : Stateless
    {
        public event Action<ExecToken> ProcessRunning;

        public event Action<ExecToken> ProcessRan;

        protected IWfChannel Channel {get; set;}

        protected CmdArgs Args {get; set;}

        protected FilePath SourcePath {get; set;}

        protected FilePath TargetPath {get; set;}

        protected abstract FilePath ToolPath {get;}

        protected virtual string RunningMsg => $"Executing {ToolPath}:{Args}";

        protected virtual string RanMsg => $"Executed {ToolPath}:{Args}";
        
        protected ToolProcess()
        {

        }


        void OnStart(ExecToken token)
        {

        }

        void OnFinish(ExecToken token)
        {

        }
        
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

        public Task<ExecToken> Start(CmdArgs args)
        {
            var flow = Running();
            var task = ToolExec.redirect(Channel, ToolPath, args, TargetPath);            
            return task.ContinueWith(t => Ran(flow));  
        }
    }
}