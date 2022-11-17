//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IApiCmdMethod
    {
        Outcome Run(IWfChannel channel, CmdArgs args);

        ApiOp Def {get;}

        ref readonly Name CmdName
            => ref Def.CmdName;
    }
}