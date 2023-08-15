//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAsmChecker
    {
        ExecToken RunCheck(string name, EventReceiver dst);
    }

    class AsmChecker : IAsmChecker
    {
        public static IAsmChecker create(IWfRuntime wf, Type host, IApiCmdRunner runner)
            => new AsmChecker(wf,host,runner);

        readonly IApiCmdRunner Runner;

        readonly IWfChannel Channel;
        
        readonly Type Host;

        public AsmChecker(IWfRuntime wf, Type host, IApiCmdRunner runner)
        {
            Channel = wf.Channel;
            Runner = runner;
            Host = host;
        }

        RunningEvent<string> Running(string name, EventReceiver dst)
        {
            var e = Events.running(Host, $"Running {text.squote(name)}");
            dst(e);
            return e;
        }

        RanEvent<string> Ran(RunningEvent<string> running, string name, EventReceiver dst)
        {
            var e = Events.ran(running, $"Ran {text.squote(name)}");
            dst(e);
            return e;
        }

        public ExecToken RunCheck(string name, EventReceiver dst)
        {
            var running = Running(name,dst);
            var token = Runner.RunCommand(name);
            Ran(running, name, dst);
            return token;
        }
    }
}