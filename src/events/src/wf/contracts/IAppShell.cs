//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public interface IAppShell : IDisposable
{
    void Run();

    ref readonly string[] Args {get;}
    
    void Init(IWfRuntime wf, string[] args);
}
