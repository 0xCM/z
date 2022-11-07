//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class NugetSvc : AppService<NugetSvc>
    {
        public static NuGetFeed feed(string url)
            => new NuGetFeed(url);

        public static SourceRepository repository(NuGetFeed feed)
            => Repository.Factory.GetCoreV3(feed.Format());

        public static ServiceIndexResourceV3 index(SourceRepository src)
            => src.GetResource<ServiceIndexResourceV3>();
    }

    /*
        var sourceRepository = Repository.Factory.GetCoreV3(FeedUrl);
        var serviceIndex = await sourceRepository.GetResourceAsync<ServiceIndexResourceV3>();
        var catalogIndexUrl = serviceIndex.GetServiceEntryUri("Catalog/3.0.0")?.ToString();

    */
}