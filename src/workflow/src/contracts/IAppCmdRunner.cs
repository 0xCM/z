//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IAppCmdRunner<S,T>
    {
        T Run(IWfChannel channel, S spec);
    }

    [Free]
    public interface IAppCmdRunner : IAppCmdRunner<CmdArgs,Outcome>
    {
        AppCmdMethod Def {get;}

        ref readonly Name CmdName
            => ref Def.CmdName;
    }
}