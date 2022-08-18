//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CmdDispatch : ICmdRouter
    {
        ICmdRouter Router;

        public Task<CmdResult> Dispatch<T>(T cmd)
            where T : struct, ICmd
                => Task.Factory.StartNew(() => Router.Dispatch(cmd));

        public CmdResult Run<T>(T cmd)
            where T : struct, ICmd
                => Dispatch(cmd).Result;

        void ICmdRouter.Enlist(Index<ICmdReactor> reactors)
            => Router.Enlist(reactors);

        ReadOnlySpan<CmdId> ICmdRouter.SupportedCommands
            => Router.SupportedCommands;

        CmdResult ICmdRouter.Dispatch(ICmd cmd)
            => Router.Dispatch(cmd);

        CmdResult ICmdRouter.Dispatch(ICmd cmd, string msg)
            => Router.Dispatch(cmd, msg);
    }
}