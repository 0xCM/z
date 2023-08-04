//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    /// <summary>
    /// Responsible for managing agents owned by a server
    /// </summary>
    public class AgentProcess : AgentMachine
    {
        internal AgentProcess(IAgentContext context, uint server, uint core, params IAgentMachine[] agents)
            : base(context, (server, 1u))
        {
            Agents = agents.ToList();
            CpuCore = (int)core;
        }

        readonly int CpuCore;

        /// <summary>
        /// Exposes a readonly stream of the agents under management on behalf of the server
        /// </summary>
        public IEnumerable<IAgentMachine> ServerAgents
            => Agents;

        List<IAgentMachine> Agents {get;}
            = new List<IAgentMachine>();

        protected override async Task Starting()
        {
            var thread = CurrentProcess.ProcessThread(CurrentProcess.OsThreadId);
            thread.IdealProcessor = CpuCore;
            await sys.start(() => Agents.AsParallel().ForAll(a => a.Start().Wait()));
        }

        protected override async Task Stopping()
            => await sys.start(() => Agents.AsParallel().ForAll(a => a.Stop().Wait()));
    }
}