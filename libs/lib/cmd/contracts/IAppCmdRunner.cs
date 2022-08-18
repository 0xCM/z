//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IAppCmdRunner<S,T>
    {
        T Run(S src, WfEmit emitter);
    }

    [Free]
    public interface IAppCmdRunner : IAppCmdRunner<CmdArgs,Outcome>
    {
        AppCmdDef Def {get;}

        ref readonly Name CmdName
            => ref Def.CmdName;
    }
}