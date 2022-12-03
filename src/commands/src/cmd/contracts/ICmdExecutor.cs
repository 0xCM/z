//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICmdExecutor
    {
        Task<ExecToken> Execute(IWfChannel channel, CmdContext context, ICmd command);
    }

    public interface ICmdExecutor<E,C> : ICmdExecutor
        where C : ICmd<C>, new()
        where E : ICmdExecutor, new()
    {
        Task<ExecToken> Execute(IWfChannel channel, CmdContext context, C command);
        
        Task<ExecToken> ICmdExecutor.Execute(IWfChannel channel, CmdContext context, ICmd command)
            => Execute(channel, context, (C)command);
    }
}