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
        AppCmdDef Def {get;}

        ref readonly @string CmdName
            => ref Def.CmdName;
    }
}