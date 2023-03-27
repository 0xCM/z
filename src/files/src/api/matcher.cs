//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Microsoft.Extensions.FileSystemGlobbing;
    
    using static sys;
    
    partial struct FS
    {
        public static Matcher matcher(FileQuery query)
        {
            var matcher = new Matcher();  
            var filter = query.Filter;
            iter(filter.Extensions, t => matcher.AddInclude($"${t.SearchPattern}${Z0.SearchPattern.All}" ));
            iter(filter.FileKinds, t => matcher.AddInclude($"${t.Ext().SearchPattern}${Z0.SearchPattern.All}" ));
            iter(filter.Inclusions, i => matcher.AddInclude(i.Format()));
            iter(filter.Exclusions, x => matcher.AddExclude(x.Format()));
            return matcher;
        }
    }
}