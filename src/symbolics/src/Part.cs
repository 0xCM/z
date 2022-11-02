//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
[assembly: PartId(PartId.Symbolics)]

namespace Z0.Parts
{
    public sealed class Symbolics : Part<Symbolics>
    {

    }
}

namespace Z0
{
    public static partial class XTend
    {

    }

    public static class XSvc
    {
        class ServiceCache : AppServices<ServiceCache>
        {
            public AppEnv AppEnv(IWfRuntime wf)
                => Service<AppEnv>(wf); 
        }

        static ServiceCache Services = ServiceCache.Instance;

        public static AppEnv AppEnv(this IWfRuntime wf)
            => Services.AppEnv(wf); 
    }



}
