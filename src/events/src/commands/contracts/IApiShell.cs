//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IApiShell : IAppShell
    {
        ICmdRunner Runner {get;}

        void Init(IWfRuntime wf, ReadOnlySeq<string> args, ICmdRunner dispatcher);
    }    
}