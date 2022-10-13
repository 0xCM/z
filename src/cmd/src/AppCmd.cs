//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    class AppCmd : AppCmdService<AppCmd>
    {
        protected override void Initialized()
        {            
            EmitCatalog(this);
        }

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

        void PrintAssemblies()
        {
            var src = ApiRuntime.colocated(ExecutingPart.Assembly);
            iter(src, a => Emitter.Row(FS.uri(a.Location)));
        }
    }    
}