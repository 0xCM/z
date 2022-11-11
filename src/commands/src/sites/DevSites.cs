//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public record class DevSite
    {
        public FolderPath SiteRoot;

        public FolderPath SiteBuild;

        public FolderPath SiteScripts;

        public FolderPath SiteSource;
    }

    public class DevSites : AppService<DevSites>
    {

        [Cmd(Name)]
        public record class CreateSite : ICmd<CreateSite>
        {
            public const string Name = "site/create";

            public FolderPath Location; 
        }        

    }

}