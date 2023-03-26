//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{    
    public interface IApiShell : IDisposable
    {
        void Run();
    }    

    public interface IAppShell : IApiShell, IAppService
    {
        void Init(IWfRuntime wf, IApiContext context);
    }   
}