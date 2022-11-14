//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{        
    using static sys;

    public class CmdFlows : WfSvc<CmdFlows>, ICmdRouter
    {
        ICmdRouter Router;

        public static ICmd reify(Type src)
            => (ICmd)Activator.CreateInstance(src);

        [Op]
        public static ICmd[] reify(Assembly src)
            => CmdTypes.tagged(src).Select(reify);

        // public static CmdFlows flows(IWfRuntime wf, ICmdReactor[] reactors)
        // {
        //     var dst = create(wf);
        //     var router = new WfCmdRouter(wf);
        //     router.Enlist(reactors);
        //     dst.Router = router;
        //     return dst;
        // }

        public Task<CmdResult> Start<T>(T cmd)
            where T : struct, ICmd
                => Router.Start(cmd);

        public CmdResult Run<T>(T cmd)
            where T : struct, ICmd
                => Start(cmd).Result;

        void ICmdRouter.Enlist(Index<ICmdReactor> reactors)
            => Router.Enlist(reactors);

        ReadOnlySpan<CmdId> ICmdRouter.SupportedCommands
            => Router.SupportedCommands;

        Task<CmdResult> ICmdRouter.Dispatch(ICmd cmd)
            => Router.Dispatch(cmd);

        Task<CmdResult> ICmdRouter.Dispatch(ICmd cmd, string msg)
            => Router.Dispatch(cmd, msg);
    }
}