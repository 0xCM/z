//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public record class WfInit
{
    public LogSettings LogConfig;

    public IEventBroker EventBroker;

    public AppEventSource Host;

    public IEmissionLog EmissionLog;

    public LogLevel Verbosity;
}
