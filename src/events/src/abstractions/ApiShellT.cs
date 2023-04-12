//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class ApiShell<S> : AppShell<S>, IApiShell
        where S : ApiShell<S>, new()
    {
        protected IApiCmdRunner CmdRunner;
        
        public void Init(IWfRuntime wf, ReadOnlySeq<string> args, IApiCmdRunner runner)
        {
            base.Init(wf, args);
            CmdRunner = runner;
        }

        IApiCmdRunner IApiShell.Runner
            => CmdRunner;
            
        protected override void Run()
            => ApiCmdLoop.start(Channel, CmdRunner).Wait();
    }
}