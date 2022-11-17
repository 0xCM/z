//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------


namespace Z0
{
    public static class XSvc
    {
        sealed class ServiceCache : AppServices<ServiceCache>
        {
            public AncestryChecks AncestryChecks(IWfRuntime wf)
                => Service<AncestryChecks>(wf);

            public BitLogicChecker BitLogicChecker(IWfRuntime wf)
                => Service<BitLogicChecker>(wf);

            public CalcChecker CalcChecker(IWfRuntime wf)
                => Service<CalcChecker>(wf);
        }

        static ServiceCache Services => ServiceCache.Instance;

        public static AncestryChecks AncestryChecks(this IWfRuntime wf)
            => Services.AncestryChecks(wf);

        public static BitLogicChecker BitLogicChecker(this IWfRuntime wf)
            => Services.BitLogicChecker(wf);

        public static IApiCmdSvc CalcChecker(this IWfRuntime wf)
            => Services.CalcChecker(wf);
    }
}