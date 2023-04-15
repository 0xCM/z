//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class ToolFlow<T> : Channeled<T>, IToolFlow
        where T : ToolFlow<T>, new()
    {
        IToolStreamWriter TargetStream;

        IToolStreamWriter ErrorStream;

        ExecToken Token;

        ExecStatus Status;

        protected ToolFlow(string toolname = "")
        {
            
        }

        public ExecStatus Run(ToolCmd command, FilePath dst)
        {
            using var flow = create(Channel);
            return flow.Start(command, dst).Result;
        }

        public ExecStatus Run(ToolCmd command)
        {
            using var flow = create(Channel);
            return flow.Start(command).Result;
        }

        protected virtual IToolStreamWriter CreateStatusWriter(FilePath dst)
            => Tooling.writer(dst);

        protected virtual IToolStreamWriter CreateErrorWriter(FilePath dst)
            => Tooling.writer(dst);

        Task<ExecStatus> Start(ToolCmd cmd, FilePath dst)   
        {
            TargetStream = CreateStatusWriter(dst);
            ErrorStream = CreateErrorWriter(dst + FS.ext("errors"));
            var status = Tooling.start(this, cmd);
            return status;
        }

        Task<ExecStatus> Start(ToolCmd cmd)   
            => Tooling.start(this, cmd);

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
            ErrorStream?.Write(src);
            OnError(src);
        }

        void IToolFlow.OnStatus(TextLine src)
        {
            TargetStream?.Write(src);
            OnStatus(src);
        }

        protected virtual void OnStatus(TextLine src)
        {
            if(TargetStream == null)
                Channel.Row(src);
        }

        protected virtual void OnError(TextLine src)
        {
            if(ErrorStream == null)
                Channel.Error(src);
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
