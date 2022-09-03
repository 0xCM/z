//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    sealed class App : AppCmdShell<App>
    {   
        public static void Main(params string[] args)
            => run(wf => AppCmd.service(wf), false, args);
    }
}