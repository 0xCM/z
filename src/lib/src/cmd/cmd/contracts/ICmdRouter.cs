//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ICmdRouter
    {
        ReadOnlySpan<CmdId> SupportedCommands {get;}

        void Enlist(Index<ICmdReactor> reactors);

        CmdResult Dispatch(ICmd cmd);

        CmdResult Dispatch(ICmd cmd, string msg);
    }
}