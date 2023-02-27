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
    public class AgentProcess : Agent
    {
        internal AgentProcess(IAgentContext context, uint server, uint core, params IAgent[] agents)
            : base(context, (server, 1u))
        {
            Agents = agents.ToList();
            CpuCore = (int)core;
        }

        readonly int CpuCore;

        /// <summary>
        /// Exposes a readonly stream of the agents under management on behalf of the server
        /// </summary>
        public IEnumerable<IAgent> ServerAgents
            => Agents;

        List<IAgent> Agents {get;}
            = new List<IAgent>();

        protected override void OnStart()
        {
            var thread = CurrentProcess.ProcessThread(CurrentProcess.OsThreadId);
            thread.IdealProcessor = CpuCore;
            //core.thread(CurrentProcess.OsThreadId).OnSome(t => t.IdealProcessor = CoreNumber);
            foreach(var src in Agents)
                src.Start();
        }

        protected override void OnStop()
        {
            Agents.AsParallel().ForAll(a => a.Stop().Wait());
        }
    }
}