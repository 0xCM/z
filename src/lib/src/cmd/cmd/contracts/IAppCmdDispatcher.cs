//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAppCmdDispatcher
    {
        Outcome Dispatch(string action, CmdArgs args);

        Outcome Dispatch(string action);

        IAppCommands Commands {get;}

        PartName Controller 
            => ExecutingPart.Name;
    }
}