//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IToolExecutor
    {
        Task<ExecToken> Execute(ToolContext context, ICmd command);
    }

    // public interface IToolExecutor<C,P> : IToolExecutor
    //     where C : ICmd, new()
    //     where P : INullity, new()
    // {
    //     Task<CmdResult<C,P>> Execute(ToolContext context, C command);
        
    //     Task<ExecToken> IToolExecutor.Execute(ToolContext context, ICmd command)
    //     {
    //         ExecToken Exec()
    //             => Execute(context, (C)command).Result.Token;
            
    //         return sys.start(Exec);
    //     }
    // }
}