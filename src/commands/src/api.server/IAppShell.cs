//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAppShell : IAppService
    {
        void OnExit();

        void Run(string[] args);

        void Init(IWfRuntime wf, IApiServerContext context);
    }   
}