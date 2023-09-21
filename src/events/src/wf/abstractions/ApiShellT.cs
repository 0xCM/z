//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public abstract class ApiShell<S> : AppShell<S>, IApiShell
    where S : ApiShell<S>, new()
{
    public IApiCmdRunner Runner {get; private set;}
    
    public void Init(IWfRuntime wf, string[] args, IApiCmdRunner runner)
    {
        base.Init(wf, args);
        Runner = runner;
    }

    protected ApiShell()
    {
        Disposing += HandleDispose;
    }

    void HandleDispose()
    {
        Runner?.Dispose();
    }

    protected override void Run()
        => ApiCmdLoop.start(Channel, Runner).Wait();
}
