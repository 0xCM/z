//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    class AppCmd : AppCmdService<AppCmd>
    {
        public static ICmdProvider[] providers(IWfRuntime wf)
            => new ICmdProvider[]{
                wf.ApiCmd(),
                wf.AncestryChecks(),
                wf.AsmCoreCmd(),
                wf.AsmCmdSvc(),
                wf.AsmChecks(),
                wf.CaptureCmd(),
                wf.AsmDbCmd(),
                wf.CliCmd(),
                wf.DbCmd(),
                wf.LlvmCmd(),
                wf.RoslynCmd(),
                wf.IntelInxCmd(),
                wf.Machines(),
                wf.ProjectCmd(),
                wf.RuntimeCmd(),
                wf.ToolCmd(),
                wf.WfCmd(),
                wf.RoslynCmd(),
                wf.XedCmd(),
                wf.XedChecks(),
                wf.BuildCmd(),
                wf.XedToolCmd(),
                wf.FsmCmd(),
                wf.CalcChecker(),
                wf.TestCmd(),
                wf.AsmGenCmd(),
                wf.SosCmd(),
                wf.CsGenCmd(),
                wf.MemoryChecks(),
                wf.CgChecks(),
                };

        public static AppCmd service(IWfRuntime wf)
        {
            GlobalServices.Instance.Inject(wf.XedRuntime());
            var flow = wf.Running("Creating application host");
            var providers = AppCmd.providers(wf);
            var cmd = Cmd.service<AppCmd>(wf, providers);
            wf.Ran(flow, $"Created application host with {providers.Length} command providers");
            return cmd;
        }

        protected override void Initialized()
        {            
            EmitCatalog(this);
        }

        void EmitCatalog(IAppCmdSvc src)
        {
            var counter = 0u;
            iter(src.Providers.View, provider => {
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

        void LoadCatalog()
        {
            Emitter.Write($"Providers:{Providers.Count}");
            iter(Providers, p => Emitter.Row(p.GetType().DisplayName()));
        }

        void PrintAssemblies()
        {
            var src = ApiRuntime.colocated(ExecutingPart.Assembly);
            iter(src, a => Emitter.Row(FS.uri(a.Location)));
        }
    }    
}