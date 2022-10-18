//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static class XSvc
    {
        class ServiceCache : AppServices<ServiceCache>
        {
            public OmniScript OmniScript(IWfRuntime wf)
                => Service<OmniScript>(wf);

            public ProjectScripts ProjectScripts(IWfRuntime wf)
                => Service<ProjectScripts>(wf);

            public WsRegistry WsRegistry(IWfRuntime wf)
                => Service<WsRegistry>(wf);            

            public Reactor Reactor(IWfRuntime wf)
                => Service<Reactor>(wf);            

            public IWfServices WfServices(IWfRuntime wf)
                => Service<WfServices>(wf);

            public DbCmd DbCmd(IWfRuntime wf)
                => Service<DbCmd>(wf);

             public Tooling Tooling(IWfRuntime wf)
                => Service<Tooling>(wf);


            public DevPacks DevPacks(IWfRuntime wf)
                => Service<DevPacks>(wf);



        }

        static ServiceCache Services => ServiceCache.Instance;

        public static ICmdProvider DbCmd(this IWfRuntime wf)
            => Services.DbCmd(wf);

        public static OmniScript OmniScript(this IWfRuntime wf)
            => Services.OmniScript(wf);

        public static Reactor Reactor(this IWfRuntime wf)
            => Services.Reactor(wf);

        public static ProjectScripts ProjectScripts(this IWfRuntime wf)
            => Services.ProjectScripts(wf);

        public static WsRegistry WsRegistry(this IWfRuntime wf)
            => Services.WsRegistry(wf);
 
        public static IWfServices WfServices(this IWfRuntime wf)
            => Services.WfServices(wf);

        public static DevPacks DevPacks(this IWfRuntime wf)
            => Services.DevPacks(wf);
       public static Tooling Tooling(this IWfRuntime wf)
            => Services.Tooling(wf);             

    }
}