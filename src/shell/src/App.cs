//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    sealed class App : AppCmdShell<App>
    {
        static ReadOnlySeq<ICmdProvider> providers(IWfRuntime wf)
            => new ICmdProvider[]{
                wf.WfCmd(),
                wf.BuildCmd(),
            };

        static int main(string[] args)
        {
            var result = 0;
            using var app = ApiRuntime.shell<App>(false, args);
            var context = WfServices.context<AppShellCmd>(app.Wf, () => providers(app.Wf));
            var channel = context.Channel;
            app.Commander = context.Commander;
            if(args.Length == 0)
                app.Run(sys.empty<string>());
            else
            {
                try
                {

                }
                catch(Exception e)
                {
                    app.Channel.Error(e);
                    result = -1;
                }
            }
            return result;
        }

        public static int Main(params string[] args)
            => main(args);
    }

    sealed class AppShellCmd : WfAppCmd<AppShellCmd>
    {

    }
}