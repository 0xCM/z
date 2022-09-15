//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
 
    partial class Cmd
    {
        public static AppCommands distill(IAppCommands[] src)
        {
            var dst = dict<string,IAppCmdRunner>();
            foreach(var a in src)
                iter(a.Invokers,  a => dst.TryAdd(a.CmdName, a));
            return new AppCommands(dst);
        }
    }
}