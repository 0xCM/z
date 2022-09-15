//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public sealed class CmdRouter : ICmdRouter
    {
        ConcurrentDictionary<CmdId,ICmdReactor> Nodes;

        readonly IWfRuntime Wf;

        readonly WfEmit Channel;

        public CmdRouter(IWfRuntime wf)
        {
            Wf = wf;
            Channel = wf.Emitter;
            Nodes = new ConcurrentDictionary<CmdId,ICmdReactor>();
        }

        public ReadOnlySpan<CmdId> SupportedCommands
            => Nodes.Keys.Array();

        public void Enlist(Index<ICmdReactor> src)
        {
            var count = 0;
            foreach(var reactor in src)
            {
                if(Nodes.TryAdd(reactor.CmdId, reactor))
                    count++;
            }
            iter(src, cmd => Nodes.TryAdd(cmd.CmdId, cmd));
        }

        public CmdResult Dispatch(ICmd cmd, string msg)
        {
            using var dispatch = Wf.Running(msg);
            try
            {
                if(Nodes.TryGetValue(cmd.CmdId, out var node))
                {
                    Channel.Status(DispatchingCmd.Format(cmd.CmdId, node.GetType().Name));
                    var result = node.Invoke(cmd);
                    if(result.Succeeded)
                        Channel.Status(result);
                    else
                        Channel.Error(result);
                    return result;
                }
                else
                {
                    Channel.Error(AppMsg.NotFound.Format(cmd.CmdId));
                    return CmdResults.fail(cmd);
                }
            }
            catch(Exception e)
            {
                Channel.Error(e);
                return CmdResults.fail(cmd, e);
            }
        }

        public CmdResult Dispatch(ICmd cmd)
            => Dispatch(cmd, string.Format("Dispatching <{0}>", cmd.CmdId));

        public static MsgPattern<CmdId,string> DispatchingCmd => "Dispatching {0} command to {1}";
    }
}