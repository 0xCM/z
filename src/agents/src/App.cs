//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    sealed class App : AgentShell<App>
    {
        public static int Main(string[] args)
            => run(args);

        protected override IEnumerable<IAgent> CreateAgents(IWfRuntime wf)
            => new IAgent[]{new ProcessTracer(wf)};
    }
}