//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IApiDispatcher : IActor
    {
        ReadOnlySeq<IApiCmdProvider> Providers {get;}

        Outcome Dispatch(string action, CmdArgs args);

        Outcome Dispatch(string action);

        IApiOps Commands {get;}

        PartName Controller 
            => ExecutingPart.Name;
    }
}