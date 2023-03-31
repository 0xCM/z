//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class ToolFlow<T> : Channeled<T>, IToolFlow
        where T : ToolFlow<T>, new()
    {
        FilePath SourcePath;

        IToolStreamWriter TargetStream;

        IToolStreamWriter ErrorStream;

        ExecToken Token;

        ExecStatus Status;

        protected readonly string ToolName;

        protected ToolFlow(string toolname)
        {
            ToolName = toolname;
        }

        public ExecStatus Run(CmdArgs args, FilePath tool, FilePath src, FilePath dst)
        {
            using var flow = create(Channel);
            return flow.Start(args, tool, src,dst).Result;
        }

        protected virtual IToolStreamWriter CreateStatusWriter(FilePath dst)
            => ToolFlows.writer(dst);

        protected virtual IToolStreamWriter CreateErrorWriter(FilePath dst)
            => ToolFlows.writer(dst);

        Task<ExecStatus> Start(CmdArgs args, FilePath tool, FilePath src, FilePath dst)   
        {
            var spec = ToolExec.spec(tool, args);  
            SourcePath = src;
            TargetStream = CreateStatusWriter(dst);
            ErrorStream = CreateErrorWriter(dst + FS.ext("errors"));
            var status = ToolFlows.start(this, spec);
            return status;
        }
        
        void IToolFlow.OnStart(ExecToken token)
        {
            Token = token;
        }

        void IToolFlow.OnFinish(ExecStatus status)
        {
            Status = status;
        }
        
        void IToolFlow.OnError(TextLine src)
        {
            ErrorStream.Write(src);
            OnError(src);
        }

        void IToolFlow.OnStatus(TextLine src)
        {
            TargetStream.Write(src);
            OnStatus(src);
        }

        protected virtual void OnStatus(TextLine src)
        {

        }

        protected virtual void OnError(TextLine src)
        {
            
        }

        ExecFlow<M> IToolFlow.Running<M>(M msg)
            => Channel.Running(msg);

        ExecToken IToolFlow.Ran<M>(ExecFlow<M> flow, string msg)
            => Channel.Ran(flow,msg);

        void Dispose()
        {
            TargetStream?.Dispose();
            ErrorStream?.Dispose();

        }
        void IDisposable.Dispose()
        {
            Dispose();
        }
    }
}
