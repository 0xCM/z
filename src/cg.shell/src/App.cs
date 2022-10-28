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
                CgCmd.create(wf)
            };

        public static void main(string[] args)
        {
            using var app = ApiRuntime.shell<App>(false, args);
            var context = WfCmd.context<CgCmd>(app.Wf, () => providers(app.Wf));
            var channel = context.Channel;
            app.Commander = context.Commander;
            app.Run(args);
        }        

        public static void Main(params string[] args)
            => main(args);
    }

    partial class CgCmd : WfAppCmd<CgCmd>
    {

    }    
}