//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IWfDispatcher : IWfCmdRouter
    {
        ReadOnlySeq<ICmdProvider> Providers {get;}

        Outcome Dispatch(string action, CmdArgs args);

        Outcome Dispatch(string action);

        IWfCmdSpecs Commands {get;}

        PartName Controller 
            => ExecutingPart.Name;
    }
}