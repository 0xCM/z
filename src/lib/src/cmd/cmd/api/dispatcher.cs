//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
 
    partial class Cmd
    {
        public static IAppCmdDispatcher dispatcher<T>(T service, WfEmit channel, ReadOnlySeq<ICmdProvider> providers)
        {
            var flow = channel.Running($"Discovering {service} dispatchers");
            var dst = dict<string,IAppCmdRunner>();
            iter(runners(service), r => dst.TryAdd(r.Def.CmdName, r));
            iter(providers, p => iter(runners(p), r => dst.TryAdd(r.Def.CmdName, r)));            
            return new AppCmdDispatcher(channel, providers, new AppCommands(dst));
        }
    }
}