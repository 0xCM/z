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


        void EmitCatalog(AppCmd service)
        {
            var counter = 0u;
            var providers = service.Providers;
            iter(service.Providers.View, provider => {
                var type = provider.GetType();
                var part = type.Assembly.PartName();
                var assembly = FS.path(type.Assembly.Location).ToUri();

                Channel.Write($"{assembly}:{type.DisplayName()}");
                var methods = type.DeclaredInstanceMethods().Tagged<CmdOpAttribute>();

                iter(methods, method =>{
                    var tag = method.Tag<CmdOpAttribute>().Require();
                    var kind = EnumRender.format(CmdKind.App);
                    var p = part.Format();
                    var h = type.Name.ToLower();
                    var n = tag.Name;
                    var uri = Cmd.uri(CmdKind.App, p, h,n);
                    Channel.Write(string.Format("{0:D3} {1}", counter++, uri));
                });                        
            }
                );
        }

        protected override void Run()
        {
            var service = AppCmd.service(Wf);
            var dst = bag<AppCmdRunner>();
            iter(service.Providers, p => iter(Cmd.runners(p), r => dst.Add(r)));
            service.Run();
        }        
    }
}