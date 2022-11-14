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

        public IApiCatalog ApiCatalog {get;}
        
        public PartName AppName {get;}

        public KillMe Host {get; private set;}

        public LogLevel Verbosity {get; private set;}

        public IWfEmissions Emissions {get; private set;}

        public WfEmit Emitter {get;}

        TokenDispenser Tokens;
    
        public ReadOnlySeq<string> Args {get;}

        [MethodImpl(Inline)]
        public WfRuntime(WfInit init)
        {
            Args = init.Args;
            Tokens = init.Tokens;
            EventBroker = init.EventBroker;
            Host = init.Host;
            Verbosity = LogLevel.Status;
            ApiCatalog = init.ApiCatalog;
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
            => Tokens.Open();

        public ExecToken Completed(ExecFlow src)
            => Tokens.Close(src.Token);

        public ExecToken Completed<T>(ExecFlow<T> src)
            => Tokens.Close(src.Token);

        public void Dispose()
        {
            EventBroker.Dispose();
            Emissions?.Dispose();
        }
        
        string ITextual.Format()
            => AppName.Format();
    }
}