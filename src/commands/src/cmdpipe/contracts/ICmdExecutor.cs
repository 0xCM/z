//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICmdExecutor
    {
        Task<ExecToken> Execute(CmdContext context, ICmd command);
    }

    public interface ICmdExecutor<C,P> : ICmdExecutor
        where C : IApiCmd, new()
        where P : INullity, new()
    {
        Task<CmdResult<C,P>> Execute(CmdContext context, C command);
        
        Task<ExecToken> ICmdExecutor.Execute(CmdContext context, ICmd command)
        {
            ExecToken Exec()
                => Execute(context, (C)command).Result.Token;
            
            return sys.start(Exec);
        }
    }
}