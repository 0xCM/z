//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    sealed class App : AppCmdShell<App>
    {   
        WfEmit Channel;

        public static void Main(params string[] args)
        {
            run(wf => AppCmd.service(wf), false, args);
        }


        // protected override void Run()
        // {
        //     var service = AppCmd.service(Wf);
        //     var dst = bag<AppCmdRunner>();
        //     iter(service.Providers, p => iter(Cmd.runners(p), r => dst.Add(r)));
        //     service.Run();
        // }        
    }
}