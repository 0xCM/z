//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.Linq;

/// <summary>
/// Agent that manages a collection of servers
/// </summary>
public sealed class AgentComplex : AgentMachine
{
    AgentServer[] Servers;

    IAgentMachine Controller;

    internal static Option<AgentComplex> Complex {get; set;}

    static AgentIdentity Identity
        => (UInt32.MaxValue, UInt32.MaxValue);

    internal AgentComplex(IAgentContext Context)
        : base(Context, Identity)
    {
        Servers = sys.empty<AgentServer>();
    }

    public void Configure(IEnumerable<AgentServerConfig> config, IAgentMachine controller)
    {
        var configs = config.ToArray();
        Servers = new AgentServer[configs.Length];
        for(var i=0; i<configs.Length; i++)
            Servers[i] = Agents.server(Context, configs[i]);
        Controller = controller;
    }

    Task<ParallelQuery<Task>> StartServers()
        => sys.start(() => from server in Servers.AsParallel() select server.Start());

    Task<ParallelQuery<Task>> StopServers()
        => sys.start(() => from server in Servers.AsParallel() select server.Stop());

    protected override async Task Starting()
    {
        await Controller.Start();
        await StartServers();                        
    }

    protected override async Task Stopping()
    {
        await StopServers();
        await Controller.Stop();
    }
}
