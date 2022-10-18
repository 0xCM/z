//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
[assembly: PartId("zfx")]
namespace Z0.Parts
{
    public sealed class ZFx : Part<ZFx>
    {

    }
}

namespace Z0
{
    using static sys;

    sealed class AppSvc : WfSvc<AppSvc>
    {
        void EmitCatalog(IAppCmdSvc src)
        {
            var counter = 0u;
            iter(src.Dispatcher.Providers.View, provider => {
                var type = provider.GetType();
                var part = type.Assembly.PartName();
                var assembly = FS.path(type.Assembly.Location).ToUri();
                Emitter.Write($"{assembly}:{type.DisplayName()}");
                var methods = type.DeclaredInstanceMethods().Tagged<CmdOpAttribute>();

                iter(methods, method =>{
                    var tag = method.Tag<CmdOpAttribute>().Require();
                    var kind = EnumRender.format(CmdKind.App);
                    var p = part.Format();
                    var h = type.Name.ToLower();
                    var n = tag.Name;
                    var uri = AppCmd.uri(CmdKind.App, p, h,n);
                    Emitter.Write(string.Format("{0:D3} {1}", counter++, uri));
                });                        
            }
                );
        }
    }


    [Free]
    sealed class App : AppCmdShell<App>
    {
        
        public static void Main(params string[] args)
        {

            // using var app = AppShells.create<App>(false, args);            
            // var wf = app.Wf;            

            // wf.Write($"ws:{Env.cd()}");
            // var spec = Cmd.args(args.Map(Cmd.arg));
            
            

            // var providers = new ICmdProvider[]{
            //     wf.WfCmd(),
            //     wf.BuildCmd(),
            //     wf.DbCmd() 
            // };
            // wf.Ran(running, $"Created {providers.Length} command providers");
            // app.CmdService = Cmd.service<AppShellCmd>(wf, CmdPublic.providers(wf).Init(wf).Array());
            // app.Run(args);
        }
    }

    sealed class AppShellCmd : AppCmdService<AppShellCmd>
    {
        
    }

    // sealed class ShellCommands : AppCmdService<ShellCommands>
    // {

    // }
    // sealed class App : AppCmdShell<App>
    // {   
    //     public static void Main(params string[] args)
    //     {
    //         using var app = AppShells.create<App>(false, args);    
    //         //var dispatcher = app.Wf.CmdPublic().Dispatcher;
    //         app.CmdService = Cmd.service<ShellCommands>(app.Wf, CmdPublic.providers(app.Wf).Array());
    //         //app.CmdService = app.Wf.CmdPublic();
    //         //app.PrintAssemblies();
    //         app.Run(args);
            

    //         // var commands = app.Wf.CmdPublic();
    //         // app.CmdService = commands;
    //         // app.Run(args);                        
    //     }

    //     void PrintAssemblies()
    //     {
    //         var src = ApiRuntime.colocated(ExecutingPart.Assembly);
    //         iter(src, a => Emitter.Row(FS.uri(a.Location)));
    //     }
    // }
}