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

        public WfHost Host {get; private set;}

        public LogLevel Verbosity {get; private set;}

        public IWfEmissionLog Emissions {get; private set;}

        TokenDispenser Tokens;

        [MethodImpl(Inline)]
        public WfRuntime(WfInit init)
        {
            Tokens = init.Tokens;
            EventBroker = init.EventBroker;
            Host = init.Host;
            Verbosity = LogLevel.Status;
            //Settings = init.Settings;
            ApiCatalog = init.ApiCatalog;
            AppName = ExecutingPart.Assembly.PartName();
            Emissions = init.EmissionLog;           
        }

        public IEventSink EventSink
        {
            [MethodImpl(Inline)]
            get => EventBroker.Sink;
        }

        public void RedirectEmissions(IWfEmissionLog dst)
        {
            Emissions.Close();
            Emissions = dst;
        }

        [MethodImpl(Inline)]
        public ExecToken NextExecToken()
            => Tokens.Open();

        public ExecToken Completed(WfExecFlow src)
            => Tokens.Close(src.Token);

        public ExecToken Completed<T>(WfExecFlow<T> src)
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