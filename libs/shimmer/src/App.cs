//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    sealed class App : AppShell<App>
    {                
        public static void Main(params string[] args)
            => shell(args).Run();

        protected override void Run()
        {
            var shim = Shims.dynamic();
        }
    }
}