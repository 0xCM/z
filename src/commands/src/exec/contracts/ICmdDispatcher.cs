
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IApiDispatcher : IActor
    {
        Outcome Dispatch(string action, CmdArgs args);

        Outcome Dispatch(string action);

        IApiOps Commands {get;}

        PartName Controller 
            => ExecutingPart.Name;
    }
        
    public interface ICmdDispatcher
    {
        Task<ExecToken> Dispatch(ICmd cmd);
    }

    public interface ICmdDispatcher<C> : ICmdDispatcher
        where C : ICmd, new()
    {
        Task<ExecToken> Dispatch(C cmd);

        Task<ExecToken> ICmdDispatcher.Dispatch(ICmd cmd)
            => Dispatch((C)cmd);
    }
}