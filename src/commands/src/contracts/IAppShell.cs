//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{    
    public interface IApiShell : IDisposable
    {
        ReadOnlySeq<string> Args {get;}

        void Run();
    }    

    public interface IAppShell : IApiShell, IAppService
    {
        void Init(IWfRuntime wf, IApiContext context, params string[] args);
    }   
}