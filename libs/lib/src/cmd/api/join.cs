//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
 
    partial class Cmd
    {
        public static string join(CmdArgs args)
        {
            var dst = text.emitter();
            for(var i=0; i<args.Count; i++)
            {
                if(i != 0)
                    dst.Append(Chars.Space);
                dst.Append(args[i].Value);
            }

            return dst.Emit();
        }

        public static AppCommands join(IAppCommands[] src)
        {
            var dst = dict<string,IAppCmdRunner>();
            foreach(var a in src)
                iter(a.Invokers,  a => dst.TryAdd(a.CmdName, a));
            return new AppCommands(dst);
        }
    }
}