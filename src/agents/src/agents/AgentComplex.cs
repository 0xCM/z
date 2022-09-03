//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq;

    /// <summary>
    /// Agent that manages a collection of servers
    /// </summary>
    public class AgentComplex : Agent
    {
        AgentServer[] Servers;

        IAgent Controller;

        internal static Option<AgentComplex> Complex {get; set;}

        static AgentIdentity Identity
            => (UInt32.MaxValue, UInt32.MaxValue);

        internal AgentComplex(AgentContext Context)
            : base(Context, Identity)
        {
            Servers = new AgentServer[]{};
        }

        public void Configure(IEnumerable<AgentServerConfig> config, IAgent controller)
        {
            var configs = config.ToArray();
            Servers = new AgentServer[configs.Length];
            for(var i=0; i<configs.Length; i++)
                Servers[i] = Agents.server(Context, configs[i]);

            Controller = controller;
        }

        protected override async void OnStart()
        {
            await Controller.Start();
            Servers.Select(x => x.Start()).ToList();
        }

        protected override async void OnStop()
        {
            Servers.Select(x => x.Stop()).ToList();
            await Controller?.Stop();
        }

        protected override void OnTerminate()
            => Controller.Dispose();

        public override void Dispose()
        {
            Stop().Wait();
            Terminate().Wait();
        }
    }
}