//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public abstract class AgentShell<S> : ApiShell<S>
        where S : AgentShell<S>, new()
    {
        ReadOnlySeq<IAgent> Agents;
        
        protected override void Run()
        {
            Agents = CreateAgents(Wf).Array();
            sys.iter(Agents, agent => agent.Start());
            ApiCmdLoop.start(Channel, CmdRunner).Wait();
        }

        protected abstract IEnumerable<IAgent> CreateAgents(IWfRuntime wf);

        public static int run(params string[] args)
        {
            var result = 0;
            using var app = ApiServers.shell<S>(args);
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
}