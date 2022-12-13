
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICmdDispatcher
    {
        Outcome Dispatch(string action, CmdArgs args);

        Outcome Dispatch(string action);

        Task<ExecToken> Dispatch(ICmd cmd);

        ICmdActors Commands {get;}

        PartName Controller 
            => ExecutingPart.Name;
    }
        
    public interface ICmdDispatcher<C> : ICmdDispatcher
        where C : ICmd, new()
    {
        Task<ExecToken> Dispatch(C cmd);

        Task<ExecToken> ICmdDispatcher.Dispatch(ICmd cmd)
            => Dispatch((C)cmd);
    }
}