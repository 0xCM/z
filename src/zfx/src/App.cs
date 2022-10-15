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
                    var uri = Cmd.uri(CmdKind.App, p, h,n);
                    Emitter.Write(string.Format("{0:D3} {1}", counter++, uri));
                });                        
            }
                );
        }



    }
    sealed class App : AppCmdShell<App>
    {   
        public static void Main(params string[] args)
        {
            using var app = AppShells.create<App>(false, args);
        
            app.PrintAssemblies();
            // var commands = app.Wf.CmdPublic();
            // app.CmdService = commands;
            // app.Run(args);                        
        }

        void PrintAssemblies()
        {
            var src = ApiRuntime.colocated(ExecutingPart.Assembly);
            iter(src, a => Emitter.Row(FS.uri(a.Location)));
        }
    }
}