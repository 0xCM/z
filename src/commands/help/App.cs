//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
[assembly: PartId("cmd.help")]
namespace Z0
{
    using static sys;

    class App : AppShell<App>
    {
        static int Main(params string[] args)
        {
            var result = 0;
            using var shell = AppShells.create<App>(false,args);
            shell.Run(args);
            return result;
        }

        protected override void Run(string[] args)
        {
            if(args.Length != 0)
            {
                var tool = Tools.tool(first(args));
                var ops = slice(args,1).ToArray();
            
            }
        }
    }
}