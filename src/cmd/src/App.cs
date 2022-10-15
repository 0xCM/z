//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    sealed class App : AppCmdShell<App>
    {   
        public static void Main(params string[] args)
        {
            using var app = AppShells.create<App>(false, args);
            var commands = app.Wf.CmdPublic();
            app.CmdService = commands;
            app.Run(args);            
        }
    }
}