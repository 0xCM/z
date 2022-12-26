//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public partial class WfRuntime : IWfRuntime
    {
        public IEventBroker EventBroker {get;}

        public PartName AppName {get;}

        public LogLevel Verbosity {get; private set;}

        public IWfEmissions Emissions {get; private set;}

        public WfEmit Emitter {get;}

        TokenDispenser Tokens;

        [MethodImpl(Inline)]
        public WfRuntime(WfInit init)
        {
            Tokens = init.Tokens;
            EventBroker = init.EventBroker;
            Verbosity = init.Verbosity;
            AppName = ExecutingPart.Assembly.PartName();
            Emissions = init.EmissionLog;           
            Emitter = WfEmit.create(this, init.Host);
        }

        public IEventSink EventSink
        {
            [MethodImpl(Inline)]
            get => EventBroker.Sink;
        }

        public void RedirectEmissions(IWfEmissions dst)
        {
            Emissions.Close();
            Emissions = dst;
        }

        [MethodImpl(Inline)]
        public ExecToken NextExecToken()
            => TokenDispenser.open();

        public ExecToken Completed(ExecFlow src, bool success = true)
            => TokenDispenser.close(src, success);

        public ExecToken Completed(FileEmission src)
            => TokenDispenser.close(src);

        public ExecToken Completed<T>(ExecFlow<T> src, bool success = true)
            => TokenDispenser.close(src, success);

        public void Dispose()
        {
            EventBroker.Dispose();
            Emissions?.Dispose();
        }
        
        string ITextual.Format()
            => AppName.Format();
    }
}