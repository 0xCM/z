//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[ApiHost]
public class WfRuntime : IWfRuntime
{
    public IEventBroker EventBroker {get;}

    public PartName AppName {get;}

    public LogLevel Verbosity {get; private set;}

    public IEmissionLog Emissions {get; private set;}

    public IWfChannel Channel {get;}

    [MethodImpl(Inline)]
    public WfRuntime(WfInit init)
    {
        EventBroker = init.EventBroker;
        Verbosity = init.Verbosity;
        AppName = ExecutingPart.Assembly.PartName();
        Emissions = init.EmissionLog;           
        Channel = WfChannel.create(init);
    }

    public IEventSink EventSink
    {
        [MethodImpl(Inline)]
        get => EventBroker.Sink;
    }

    public void RedirectEmissions(IEmissionLog dst)
    {
        Emissions.Close();
        Emissions = dst;
    }

    [MethodImpl(Inline)]
    public ExecToken NextExecToken()
        => WfTokens.open();

    public ExecToken Completed(ExecFlow src, bool success = true)
        => WfTokens.close(src, success);

    public ExecToken Completed(FileEmission src)
        => WfTokens.close(src);

    public ExecToken Completed<T>(ExecFlow<T> src, bool success = true)
        => WfTokens.close(src, success);

    public void Dispose()
    {
        EventBroker.Dispose();
        Emissions?.Dispose();
    }
    
    string ITextual.Format()
        => AppName.Format();
}
