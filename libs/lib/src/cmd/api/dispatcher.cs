//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
 
    partial class Cmd
    {
        public static IAppCmdDispatcher dispatcher<T>(T service, WfEmit channel, ReadOnlySpan<ICmdProvider> providers)
        {
            var flow = channel.Running($"Discovering dispatchers available to {service}");
            var dst = dict<string,IAppCmdRunner>();
            iter(runners(service), r => dst.TryAdd(r.Def.CmdName, r));
            iter(providers, p => iter(runners(p), r => dst.TryAdd(r.Def.CmdName, r)));            
            var commands = new AppCommands(dst);
            return new AppCmdDispatcher(commands, channel);
        }

        // static AppCommands runners<T>(T src, WfEmit channel)
        // {
        //     var svc = src.GetType().DisplayName();
        //     var dst = dict<string,IAppCmdRunner>();
        //     var methods = typeof(T).DeclaredInstanceMethods().Where(x => x.Tagged<CmdOpAttribute>());
        //     foreach(var m in methods)
        //     {
        //         var tag = m.Tag<CmdOpAttribute>().Require();
        //         dst.TryAdd(tag.Name, new AppCmdRunner(tag.Name, src, m));
        //     }
        //     return new AppCommands(dst);
        // }
    }
}