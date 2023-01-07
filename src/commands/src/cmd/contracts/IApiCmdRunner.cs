//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IApiCmdRunner : IContextual<IExecutionContext>
    {
        Task<ExecToken> Start(string[] args);   

        ExecToken Run(string[] args);

        CmdHandlers Handlers {get;}
    }
}