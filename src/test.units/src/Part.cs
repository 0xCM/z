//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
[assembly: PartId(PartId.TestUnits)]
namespace Z0.Parts
{
    public sealed class TestUnits : Part<TestUnits>
    {
        public static PartAssets Assets = new PartAssets();

        public sealed class PartAssets : Assets<PartAssets>
        {

        }
    }
}

namespace Z0
{
    [Free]
    public interface IExecutable
    {
        void Execute(params string[] args);
    }

    public interface IExplicitTest : IUnitTest, IExecutable
    {

    }

    public static class XSvc
    {
        class ServiceCache : AppServices<ServiceCache>
        {

            public IAppCmdSvc TestCmd(IWfRuntime wf)
                => Service<TestCmd>(wf);
        }

        static ServiceCache Services => ServiceCache.Instance;

        public static IAppCmdSvc TestCmd(this IWfRuntime wf)
            => Services.TestCmd(wf);
    }
}