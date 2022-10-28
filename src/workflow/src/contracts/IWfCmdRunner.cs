//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IWfCmdRunner<S,T>
    {
        T Run(IWfChannel channel, S spec);
    }

    [Free]
    public interface IWfCmdRunner : IWfCmdRunner<CmdArgs,Outcome>
    {
        WfCmdMethod Def {get;}

        ref readonly Name CmdName
            => ref Def.CmdName;
    }
}