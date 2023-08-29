//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.Linq;

[Free]
public abstract class AgentServer<S> : ApiShell<S>
    where S : AgentServer<S>, new()
{
    IAgent[] Agents;

    protected virtual async Task Start()
    {
        await sys.start(() => sys.piter(Agents.AsParallel(), agent => agent.Start().Wait()));
    }

    protected virtual async Task Stop()
    {
        await sys.start(() => sys.piter(Agents.AsParallel(), agent => agent.Stop().Wait()));
    }

    async Task RunAsync()
    {
        await Start();
        await ApiCmdLoop.start(Channel, Runner);
        await Stop();
    }

    protected override void Run()
    {
        Agents = CreateAgents(Wf).Array();
        RunAsync().Wait();
    }

    protected abstract IEnumerable<IAgent> CreateAgents(IWfRuntime wf);

    public static int run(params string[] args)
    {
        var result = 0;
        using var app = ApiServer.shell<S>(args);
        var channel = app.Channel;
        try
        {
            app.Run();
        }
        catch(Exception e)
        {
            channel.Error(e);
            result = -1;
        }
        return result;
    }
}    
