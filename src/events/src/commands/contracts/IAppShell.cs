//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAppShell : IDisposable
    {
        void Run();

        void Init(IWfRuntime wf, ReadOnlySeq<string> args);
    }
}