//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    partial class Cmd
    {
        public static AppCmdDispatcher dispatcher<T>(T svc, WfEmit channel, IAppCommands actions)
            where T : ICmdService
                => dispatcher(svc.GetType().DisplayName(), actions, channel);

        public static AppCmdDispatcher dispatcher(asci32 provider, IAppCommands actions, WfEmit channel)
            => new AppCmdDispatcher(provider, actions, channel);

        public static AppCmdDispatcher dispatcher<T>(T svc, WfEmit channel, Index<ICmdProvider> providers)
        {
            var dst = dict<string,AppCmdRunner>();
            var _dst = bag<IAppCommands>();
            _dst.Add(AppCommands.discover(svc));
            iter(providers, x => _dst.Add(x.Actions));
            return dispatcher(svc.GetType().DisplayName(), Cmd.join(_dst.ToArray()), channel);
        }
    }
}