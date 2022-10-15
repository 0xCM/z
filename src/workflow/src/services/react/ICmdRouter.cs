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

        Task<CmdResult> Dispatch(ICmd cmd);

        Task<CmdResult> Dispatch(ICmd cmd, string msg);

        Task<CmdResult> Start<T>(T cmd)
            where T : struct, ICmd;

        CmdResult Run<T>(T cmd)
            where T : struct, ICmd;            
    }
}