//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAppShell : IAppService
    {
        void Run();

        void OnExit();

        void Run(string[] args);
    }
}