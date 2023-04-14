//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static partial class XSvc
    {
        internal partial class ServiceCache : AppServices<ServiceCache>
        {

        }        

        static ServiceCache Services => ServiceCache.Instance;
    }
}