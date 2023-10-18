//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
global using cpu = Z0.vcpu;
global using gcpu = Z0.vgcpu;
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
        }

        static ServiceCache Services => ServiceCache.Instance;
    }
}