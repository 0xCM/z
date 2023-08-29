//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public interface IApiShell : IAppShell
{
    IApiCmdRunner Runner {get;}

    void Init(IWfRuntime wf, ReadOnlySeq<string> args, IApiCmdRunner dispatcher);
}    
