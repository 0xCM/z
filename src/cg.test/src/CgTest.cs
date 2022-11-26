//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    sealed class App : ApiShell<App>
    {
        static IApiService commands(IWfRuntime wf)
            => CgTestCmd.create(wf);

        public static void Main(params string[] args)
        {
            
        }
    }
}