//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    sealed class App : ApiShell<App>
    {
        static ReadOnlySeq<IApiCmdProvider> providers(IWfRuntime wf)
            => new IApiCmdProvider[]{
                wf.WfCmd(),
                wf.EnvCmd(),
                wf.ImageCmd(),
                wf.ArchiveCmd(),
                wf.WinMdCmd(),
                wf.ClrCmd(),
                wf.EcmaCmd()
            };

        static int main(string[] args)
        {
            var result = 0;
            using var app = ApiServers.shell<App,AppCmd>(providers);
            try
            {
                app.Run(args);
            }
            catch(Exception e)
            {
                app.Channel.Error(e);
                result = -1;
            }
            return result;
        }

        public static int Main(params string[] args)
            => main(args);
    }

    sealed class AppCmd : WfAppCmd<AppCmd>
    {

        [CmdOp("text/vars")]
        void TextExpr()
        {
            var buffer = text.emitter();
            var prefix = AsciSymbols.Dollar;
            var fence = new AsciFence(AsciSymbols.LBrace, AsciSymbols.RBrace);
            buffer.Append("abcdefgh");
            buffer.Append(text.prefix(prefix, fence.Enclose("var1")));
            buffer.Append("ijklmnop");
            buffer.Append(text.prefix(prefix, fence.Enclose("var2")));
            buffer.Append("qrstuvwx");
            buffer.Append(text.prefix(prefix, fence.Enclose("var3")));
            var script = buffer.Emit();
            Channel.Row($"Input:{script}");
            Channel.Row($"Vars:");

            var vars = ScriptVars.extract(script, prefix, fence);
            sys.iter(vars, v => Channel.Row($"{v}"));
        }
    }
}