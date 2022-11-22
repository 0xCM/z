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
        }

        static ServiceCache Services = ServiceCache.Instance;

    }
}