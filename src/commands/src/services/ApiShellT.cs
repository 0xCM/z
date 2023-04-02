//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class ApiShell<S> : AppShell<S>, IApiShell
        where S : ApiShell<S>, new()
    {
        protected ICmdRunner CmdRunner;
        
        public void Init(IWfRuntime wf, ReadOnlySeq<string> args, ICmdRunner runner)
        {
            base.Init(wf, args);
            CmdRunner = runner;
        }

        protected override void Disposing()
        {
            
        }

        ICmdRunner IApiShell.Runner
            => CmdRunner;
            
        protected override void Run()
            => CmdLoop.start(Channel, CmdRunner).Wait();
    }
}